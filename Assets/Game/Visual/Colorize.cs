using System;
using System.Collections.Generic;
using UnityEngine;

public class Colorize
{
	public struct Node
	{
		public Node(Material mat, Color clr)
		{
			Material = mat;
			Color = clr;
		}
		public Material Material;
		public Color Color;
	}

	public ViPriorityValue<Color> StaticColor { get { return _staticColor; } }
	public bool Overrided { get { return _overrideColor.Count > 0; } }

	public void AddOverride(string name, Int32 weight, Color value)
	{
		_overrideColor.Add(name, weight, value);
		Set(_overrideColor.Value);
	}

	public void DelOverride(string name)
	{
		_overrideColor.Del(name);
		if (Overrided)
		{
			Set(_overrideColor.Value);
		}
		else
		{
			Color newColor = StaticColor.Value;
			Mod(newColor);
			_lastColor = newColor;
		}
	}

	public void Start(GameObject gameObj)
	{
		Mod(Color.black);
		_materialList.Clear();
		//
		UnityComponentList<Renderer>.Begin(gameObj, true);
		for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
		{
			Renderer iterRenderer = UnityComponentList<Renderer>.List[iter];
			Add(_materialList, iterRenderer.materials);
		}
		UnityComponentList<Renderer>.End();
		//
		_lastColor = Color.black;
	}

	public void End()
	{
		_materialList.Clear();
	}

	public void Revert()
	{
		for (int iter = 0; iter < _materialList.Count; ++iter)
		{
			Node iterNode = _materialList[iter];
			if (iterNode.Material != null)
			{
				iterNode.Material.SetColor("_FocusColor", iterNode.Color);
			}
		}
		_staticColor.Clear();
		_dynamicColor = Color.black;
		_dynamicTimeSlide = 0.0f;
		_dynamicDuration = 0.0f;
		_lastColor = Color.black;
	}

	public void AddDynamic(Color color, float duration)
	{
		Color currentDynamic = _dynamicDuration * _dynamicTimeSlide * _dynamicColor;
		if (currentDynamic.grayscale > color.grayscale)
		{
			return;
		}
		_dynamicDuration = duration;
		_dynamicColor = color;
		_dynamicTimeSlide = 1.0f / _dynamicDuration;
	}

	public void Update(float deltaTime)
	{
		Color newColor = StaticColor.Value;
		if (_dynamicDuration < deltaTime)
		{
			_dynamicDuration = 0;
			_dynamicColor = Color.black;
		}
		else
		{
			_dynamicDuration -= deltaTime;
			Color currentDynamic = _dynamicDuration * _dynamicTimeSlide * _dynamicColor;
			newColor += currentDynamic;
		}
		//
		if (!Overrided)
		{
			if (newColor != _lastColor)
			{
				Mod(newColor);
				_lastColor = newColor;
			}
		}
	}

	static void Add(List<Node> list, Material[] items)
	{
		for (int iter = 0; iter < items.Length; ++iter)
		{
			Material iterMaterial = items[iter];
			if (!iterMaterial.HasProperty("_FocusColor"))
			{
				continue;
			}
			list.Add(new Node(iterMaterial, iterMaterial.GetColor("_FocusColor")));
		}
	}

	void Set(Color color)
	{
		for (int iter = 0; iter < _materialList.Count; ++iter)
		{
			Node iterNode = _materialList[iter];
			if (iterNode.Material != null)
			{
				float oldA = iterNode.Material.color.a;
				color.a = oldA;
				iterNode.Material.color = color;
			}
		}
	}

	void Mod(Color color)
	{
		for (int iter = 0; iter < _materialList.Count; ++iter)
		{
			Node iterNode = _materialList[iter];
			if (iterNode.Material != null)
			{
				Color newColor = iterNode.Color + color;
				//newColor.a = 2.0f;
				iterNode.Material.SetColor("_FocusColor", newColor);
			}
		}
	}

	List<Node> _materialList = new List<Node>();
	//
	ViPriorityValue<Color> _staticColor = new ViPriorityValue<Color>(Color.black);
	ViPriorityValue<Color> _overrideColor = new ViPriorityValue<Color>(Color.black);
	//
	Color _dynamicColor;
	float _dynamicTimeSlide;
	float _dynamicDuration;
	//
	Color _lastColor;
}