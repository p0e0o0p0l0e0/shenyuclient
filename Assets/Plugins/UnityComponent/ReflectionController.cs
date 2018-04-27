using System;
using System.Collections.Generic;
using UnityEngine;
//

public class ReflectionController : MonoBehaviour
{
	public GameObject View;
	public List<ReflectionProbe> ProbeList = new List<ReflectionProbe>();
	public List<Texture> bakedTexure = new List<Texture>();
	public ReflectionProbe Current;
	public float Duration = 1.0f;
	public float BlendIntensity = 0.9f;

	void OnEnable()
	{
		for (int iter = 0; iter < ProbeList.Count; ++iter)
		{
			ReflectionProbe iterProbe = ProbeList[iter];
			iterProbe.bakedTexture = bakedTexure[iter];
			iterProbe.gameObject.SetActive(false);
		}
		//
		if (View != null)
		{
			Current = Select(View.transform.position);
			if (Current != null)
			{
				Current.gameObject.SetActive(true);
			}
		}
	}

	void Update()
	{
		if (View == null)
		{
			return;
		}
		//
		ReflectionProbe newProbe = null;
		if (Current == null)
		{
			newProbe = Select(View.transform.position);
		}
		else
		{
			if (Current.bounds.Contains(View.transform.position))
			{
				newProbe = Current;
			}
			else
			{
				newProbe = Select(View.transform.position);
			}
		}
		//
		if (!System.Object.ReferenceEquals(newProbe, Current))
		{
			EraseBlend(newProbe);
			if (Current != null)
			{
				_blendList.Add(Current);
			}
			Current = newProbe;
			if (newProbe != null)
			{
				newProbe.intensity = BlendIntensity;
				newProbe.gameObject.SetActive(true);
			}
		}
		//
		UpdateBlend();
	}

	ReflectionProbe Select(Vector3 pos)
	{
		for (int iter = 0; iter < ProbeList.Count; ++iter)
		{
			ReflectionProbe iterProbe = ProbeList[iter];
			if (iterProbe.bounds.Contains(pos))
			{
				return iterProbe;
			}
		}
		//
		return null;
	}

	void UpdateBlend()
	{
		if (Current == null)
		{
			return;
		}
		_blendTime += Time.deltaTime;
		float deltaValue = Time.deltaTime / Duration;
		Current.intensity = Math.Min(Current.intensity + deltaValue, 1.0f);
		//
		for (int iter = 0; iter < _blendList.Count; )
		{
			ReflectionProbe iterProbe = _blendList[iter];
			iterProbe.intensity -= deltaValue;
			if (iterProbe.intensity <= BlendIntensity)
			{
				iterProbe.gameObject.SetActive(false);
				_blendList.RemoveAt(iter);
			}
			else
			{
				++iter;
			}
		}
	}

	void EraseBlend(ReflectionProbe probe)
	{
		for (int iter = 0; iter < _blendList.Count; ++iter)
		{
			if (System.Object.ReferenceEquals(_blendList[iter], probe))
			{
				_blendList.RemoveAt(iter);
				break;
			}
		}
	}

	public void Save()
	{
		ProbeList.Clear();
		bakedTexure.Clear();
		//
		gameObject.GetComponentsInChildren<ReflectionProbe>(ProbeList);
		for (int iter = 0; iter < ProbeList.Count; ++iter)
		{
			ReflectionProbe iterProbe = ProbeList[iter];
			bakedTexure.Add(iterProbe.bakedTexture);
		}
	}

	float _blendTime = 0.0f;
	List<ReflectionProbe> _blendList = new List<ReflectionProbe>();
}
