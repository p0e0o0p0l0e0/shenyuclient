half3 EnvBRDFApprox(half3 SpecularColor, half Roughness, half NoV)
{
	// [ Lazarov 2013, "Getting More Physical in Call of Duty: Black Ops II" ]
	// Adaptation to fit our G term.
	const half4 c0 = { -1, -0.0275, -0.572, 0.022 };
	const half4 c1 = { 1, 0.0425, 1.04, -0.04 };
	half4 r = Roughness * c0 + c1;
	half a004 = min(r.x * r.x, exp2(-9.28 * NoV)) * r.x + r.y;
	half2 AB = half2(-1.04, 1.04) * a004 + r.zw;

	// Anything less than 2% is physically impossible and is instead considered to be shadowing
	// Note: this is needed for the 'specular' show flag to work, since it uses a SpecularColor of 0
	AB.y *= saturate(50.0 * SpecularColor.g);

	return SpecularColor * AB.x + AB.y;
}

half PhongApprox(half Roughness, half RoL)
{
	half a = Roughness * Roughness;			// 1 mul
											//!! Ronin Hack?
	a = max(a, 0.008);						// avoid underflow in FP16, next sqr should be bigger than 6.1e-5
	half a2 = a * a;						// 1 mul
#if defined(SHADER_API_GLES3) || defined(SHADER_API_METAL) || defined(SHADER_API_VULKAN)
	half rcp_a2 = rcp(a2);					// 1 rcp
#else
	half rcp_a2 = 1.0 / a2;					// 1 rcp
#endif
											//half rcp_a2 = exp2( -6.88886882 * Roughness + 6.88886882 );

											// Spherical Gaussian approximation: pow( x, n ) ~= exp( (n + 0.775) * (x - 1) )
											// Phong: n = 0.5 / a2 - 0.5
											// 0.5 / ln(2), 0.275 / ln(2)
	half c = 0.72134752 * rcp_a2 + 0.39674113;	// 1 mad
	half p = rcp_a2 * exp2(c * RoL - c);		// 2 mad, 1 exp2, 1 mul
												// Total 7 instr
	return min(p, rcp_a2);						// Avoid overflow/underflow on Mali GPUs
}

half3 ShiftTangent(half3 T, half3 N, half shift)
{
	return normalize(T + shift * N);
}

half HairSpecular(half3 T, half3 H, half exponent)
{
	half dotTH = dot(T, H);
	half sinTH = sqrt(1 - dotTH * dotTH);
	half dirAtten = smoothstep(-1, 0, dotTH);
	return dirAtten * pow(sinTH, exponent);
}

half GetLuminance(half3 LinearColor)
{
	return dot(LinearColor, half3(0.3, 0.59, 0.11));
}

#ifndef ENV_MIP_NUM
#	define ENV_MIP_NUM (7)
#endif

half ComputeReflectionCaptureMipFromRoughness(half Roughness)
{
	// Heuristic that maps roughness to mip level
	// This is done in a way such that a certain mip level will always have the same roughness, regardless of how many mips are in the texture
	// Using more mips in the cubemap just allows sharper reflections to be supported
	half LevelFrom1x1 = 1 - 1.2 * log2(Roughness);
	return ENV_MIP_NUM - 1 - LevelFrom1x1;
}

half3 RGBMDecode(fixed4 rgbm)
{
	return rgbm.rgb * (rgbm.a * 16.0f);
}

half3 GetNormalMappedNormal(in half3 normalColor, in half3x3 TtoW)
{
	normalColor = 2.0f * (normalColor - 0.5f);
	normalColor.g = -normalColor.g;
	return normalize(mul(normalColor, TtoW));
}

half3 GetGlow(in sampler2D tex, in float2 uv, in float intensity)
{
	half3 glowColor = tex2D(tex, uv).rgb;
	return glowColor * glowColor * intensity;
}

half3 GetSphereCaptureVector(half3 ReflectionVector, half3 WorldPosition, half4 CapturePositionAndRadius)
{
	half3 ProjectedCaptureVector = ReflectionVector;

	half3 RayDirection = ReflectionVector;
	half ProjectionSphereRadius = CapturePositionAndRadius.w * 1.2f;
	half SphereRadiusSquared = ProjectionSphereRadius * ProjectionSphereRadius;

	half3 ReceiverToSphereCenter = WorldPosition - CapturePositionAndRadius.xyz;
	half ReceiverToSphereCenterSq = dot(ReceiverToSphereCenter, ReceiverToSphereCenter);

	half3 CaptureVector = WorldPosition - CapturePositionAndRadius.xyz;
	half CaptureVectorLength = sqrt(dot(CaptureVector, CaptureVector));
	half NormalizedDistanceToCapture = saturate(CaptureVectorLength / CapturePositionAndRadius.w);

	// Find the intersection between the ray along the reflection vector and the capture's sphere
	half3 QuadraticCoef;
	QuadraticCoef.x = 1;
	QuadraticCoef.y = 2 * dot(RayDirection, ReceiverToSphereCenter);
	QuadraticCoef.z = ReceiverToSphereCenterSq - SphereRadiusSquared;

	half Determinant = QuadraticCoef.y * QuadraticCoef.y - 4 * QuadraticCoef.z;
	UNITY_BRANCH
	if (Determinant >= 0)
	{
		half FarIntersection = (sqrt(Determinant) - QuadraticCoef.y) * 0.5;

		half3 IntersectPosition = WorldPosition + FarIntersection * RayDirection;
		ProjectedCaptureVector = IntersectPosition - CapturePositionAndRadius.xyz;
	}
	return ProjectedCaptureVector;
}
