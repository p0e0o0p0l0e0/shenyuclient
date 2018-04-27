using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public struct ParticleSystemBurst
{
	public Int32 CountPre;
}

[System.Serializable]
public struct ParticleSystemInfo
{
	public bool High;
	public bool Middle;
	public bool Low;

	public ParticleSystemBurst ParticleSystemBurstPre;
}

[System.Serializable]
public class ParticleSystemObject
{
	public float Rate;
	public ParticleSystemInfo ParticleInfos;
	public ParticleSystem ParticleSystemData;
}

[System.Serializable]
public class GameObjectLevel
{
	public bool High;
	public bool Middle;
	public bool Low;

	public void UpdateState(bool active)
	{
		for (int iter = 0; iter < Object.Count; ++iter)
		{
			GameObject iterObject = Object[iter];
			if (!active)
			{
				GameObject.DestroyImmediate(iterObject);
			}
		}
	}

	public List<GameObject> Object;
}

[System.Serializable]
public class LODLevel
{
	public List<GameObjectLevel> Objects;
	public List<ParticleSystemObject> ParticleSystemInfos;
	public List<GameObject> DistortObjects;
}

public class FXLODLevel : MonoBehaviour
{
	public LODLevel Level;

	public void Emit(bool high, bool distort)
	{
		List<GameObjectLevel> objects = Level.Objects;
		for (int iter = 0; iter < objects.Count; ++iter)
		{
			GameObjectLevel iterObject = objects[iter];
			if (iterObject == null)
			{
				continue;
			}
			//
			if (iterObject.High && high)
			{
				iterObject.UpdateState(false);
			}
			else if (iterObject.Middle && !high)
			{
				iterObject.UpdateState(false);
			}
		}
		//
		List<ParticleSystemObject> particleSystemInfos = Level.ParticleSystemInfos;
		for (int iter = 0; iter < particleSystemInfos.Count; ++iter)
		{
			ParticleSystemObject iterObject = particleSystemInfos[iter];
			ParticleSystem particleSystem = iterObject.ParticleSystemData;
			if (particleSystem == null)
			{
				continue;
			}
			//
			ParticleSystemInfo info = iterObject.ParticleInfos;
			particleSystem.emissionRate = iterObject.Rate;
			if (info.High && high)
			{
				_UpdateParticleSystemEmission(info, particleSystem);
			}
			else if (info.Middle && !high)
			{
				_UpdateParticleSystemEmission(info, particleSystem);
			}
		}
		//
		List<GameObject> distortObjects = Level.DistortObjects;
		for (Int32 iter = 0; iter < distortObjects.Count; ++iter)
		{
			GameObject iterObject = distortObjects[iter];
			UnityAssisstant.SetActive(iterObject, distort);
		}
	}

	void _UpdateParticleSystemEmission(ParticleSystemInfo info, ParticleSystem particleInfo)
	{
		ParticleSystemBurst burst = info.ParticleSystemBurstPre;
		ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[particleInfo.emission.burstCount];
		particleInfo.emission.GetBursts(bursts);
		for (Int32 iter = 0; iter < bursts.Length; ++iter)
		{
			ParticleSystem.Burst iterBurst = bursts[iter];
			iterBurst.minCount = (short)(iterBurst.minCount * burst.CountPre * 0.01f);
			iterBurst.maxCount = (short)(iterBurst.maxCount * burst.CountPre * 0.01f);
			bursts[iter] = iterBurst;
		}
		//
		particleInfo.emission.SetBursts(bursts);
	}

#if UNITY_EDITOR
	void OnValidate()
	{

	}
#endif
}
