using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationAssisstant
{
	static AnimationAssisstant()
	{
		//AddAlias(AnimationData.BattleIdle, AnimationData.Idle);
		//AddAlias(AnimationData.RideIdle, AnimationData.Idle);
		//AddAlias(AnimationData.FlyIdle, AnimationData.Idle);
		//AddAlias(AnimationData.Idle2, AnimationData.Idle);
		//AddAlias(AnimationData.Idle3, AnimationData.Idle);
		//AddAlias(AnimationData.BattleRun, AnimationData.Run);
		//AddAlias(AnimationData.Attack2, AnimationData.Attack);
		//AddAlias(AnimationData.Attack3, AnimationData.Attack);
		//AddAlias(AnimationData.Spell2, AnimationData.Spell);
		//AddAlias(AnimationData.Spell3, AnimationData.Spell);
		//AddAlias(AnimationData.Spell, AnimationData.Attack);
		//AddAlias(AnimationData.Spell2, AnimationData.Attack);
		//AddAlias(AnimationData.Spell3, AnimationData.Attack);
		//AddAlias(AnimationData.Show2, AnimationData.Show);
		//AddAlias(AnimationData.Show3, AnimationData.Show);
	}

	public static void CrossFadeEx(Animation animation, string name, bool blend)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState != null)
		{
			if (blend)
			{
				animation.CrossFade(name);
			}
			else
			{
				animation.Play(name);
			}
		}
	}
	public static void CrossFadeEx(Animation animation, string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState != null)
		{
			animation.CrossFade(name);
		}
	}
	public static void CrossFadeEx(Animation animation, string name, float time)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState != null)
		{
			animation.CrossFade(name);
			animState.normalizedTime = time;
		}
	}
	public static void CrossFadeQueuedEx(Animation animation, string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState != null)
		{
			animation.CrossFadeQueued(name);
		}
	}
	public static void PlayerEx(Animation animation, string name, bool breakCurrent)
	{
		AnimationState animState = animation[name];
		if (animState != null)
		{
			if (animation.IsPlaying(name) && breakCurrent)
			{
				animation.Rewind(name);
			}
			animation.CrossFade(name, 0.2f);
		}
	}
	public static void PlayerQueuedEx(Animation animation, string name)
	{
		AnimationState animState = animation[name];
		if (animState != null)
		{
			animation.PlayQueued(name);
		}
	}
	public static void StopEx(Animation animation, string name)
	{
		AnimationState animState = animation[name];
		if (animState != null)
		{
			animState.normalizedTime = 1.0f;
		}
	}


	public static void AddAlias(string src, string alias)
	{
		List<string> aliasList;
		if (_alias.TryGetValue(src, out aliasList))
		{

		}
		else
		{
			aliasList = new List<string>();
			_alias.Add(src, aliasList);
		}
		aliasList.Add(alias);
	}

	public static string Alias(string name, Animation animation)
	{
		if (animation == null)
		{
			return name;
		}
		if (animation[name] != null)
		{
			return name;
		}
		List<string> alias;
		if (_alias.TryGetValue(name, out alias))
		{
			for (int iter = 0; iter < alias.Count; ++iter)
			{
				string aliasName = alias[iter];
				AnimationState animState = animation[aliasName];
				if (animState != null)
				{
					return aliasName;
				}
			}
		}
		//
		return name;
	}

	static Dictionary<string, List<string>> _alias = new Dictionary<string, List<string>>();
}

public class AnimationLoopLayer
{
	public void Start(Animation animation, bool blend)
	{
		if (_current == string.Empty)
		{
			_current = _default;
		}
		if (_current != string.Empty)
		{
			string animName = AnimationAssisstant.Alias(_current, animation);
			AnimationAssisstant.CrossFadeEx(animation, animName, blend);
		}
	}

	public void Revert(Animation animation)
	{
		if (_current != string.Empty)
		{
			string animName = AnimationAssisstant.Alias(_current, animation);
			AnimationAssisstant.CrossFadeEx(animation, animName, false);
		}
	}

	public void SynchronizeTo(AnimationLoopLayer layer, Animation animation)
	{
		if (_current != string.Empty && _current != _default)
		{
			layer.Play(animation, _current, false);
		}
		else
		{
			layer.Stop(animation);
		}
	}

	public void SetDefault(Animation animation, string name)
	{
		if (animation != null)
		{
			if (_current == string.Empty || IsDefault(_current))
			{
				bool blend = _current != string.Empty;
				string animName = AnimationAssisstant.Alias(name, animation);
				AnimationAssisstant.CrossFadeEx(animation, animName, blend);
				_current = name;
			}
		}
		//
		_default = name;
	}

	public void Play(Animation animation, string name, bool synTime)
	{

		if (_current == name || _current == String.Empty)
		{
			return;
		}
		if (animation != null)
		{
			string animName = AnimationAssisstant.Alias(name, animation);
			if (synTime && _current != _default)
			{
				AnimationAssisstant.CrossFadeEx(animation, animName, Progress(animation, _current));
                //Debug.Log("AnimationAssisstant.CrossFadeEx")
			}
			else
			{
				AnimationAssisstant.CrossFadeEx(animation, animName);
			}
		}
		_current = name;
	}
	public void Play(Animation animation, string name, float startTime, bool blend)
	{
		if (_current == name)
		{
			return;
		}
		if (animation != null)
		{
			string animName = AnimationAssisstant.Alias(name, animation);
			AnimationState animState = animation[animName];
			if (animState != null)
			{
				AnimationAssisstant.CrossFadeEx(animation, animName, blend);
				animState.normalizedTime = startTime;
			}
		}
		_current = name;
	}

	public bool IsPlaying(string anim)
	{
		return _current == anim;
	}

	public float Progress(Animation animation, string anim)
	{
		string oldAnimName = AnimationAssisstant.Alias(anim, animation);
		AnimationState animOldState = animation[oldAnimName];
		if (animOldState != null)
		{
			return animOldState.normalizedTime;
		}
		else
		{
			return 0.0f;
		}
	}

	public void Replace(Animation animation, string oldAnim, string newAnim)
	{
		if (_current != oldAnim)
		{
			return;
		}
		if (IsPlaying(oldAnim))
		{
			if (animation != null)
			{
				string oldAnimName = AnimationAssisstant.Alias(oldAnim, animation);
				string newAnimName = AnimationAssisstant.Alias(newAnim, animation);
				AnimationState animOldState = animation[oldAnimName];
				AnimationState animNewState = animation[newAnimName];
				if (animOldState != null && animNewState != null)
				{
					float time = animOldState.normalizedTime;
					animation.CrossFade(newAnimName);
					animNewState.normalizedTime = time;
				}
			}
		}
		_current = newAnim;
	}

	public void Stop(Animation animation, string name)
	{
		if (_current != name)
		{
			return;
		}
		if (animation != null)
		{
			if (_default != string.Empty)
			{
				string animName = AnimationAssisstant.Alias(_default, animation);
				AnimationAssisstant.CrossFadeEx(animation, animName);
			}
			else
			{
				string animName = AnimationAssisstant.Alias(_current, animation);
				AnimationState animState = animation[animName];
				if (animState != null)
				{
					animation.Stop(animName);
				}
			}
		}
		_current = _default;
	}

	public void Stop(Animation animation)
	{
		if (IsDefault(_current))
		{
			return;
		}
		if (animation != null)
		{
			if (_default != string.Empty)
			{
				string animName = AnimationAssisstant.Alias(_default, animation);
				AnimationAssisstant.CrossFadeEx(animation, animName);
			}
			else
			{
				string animName = AnimationAssisstant.Alias(_current, animation);
				AnimationState animState = animation[animName];
				if (animState != null)
				{
					animation.Stop(animName);
				}
			}
		}
		_current = _default;
	}

	public bool IsDefault(string name)
	{
		if (name == string.Empty)
		{
			return false;
		}
		if (_default == string.Empty)
		{
			return false;
		}
		return (_default == name);
	}

	public bool IsDefaultPlaying { get { return IsDefault(_current); } }

	public void Refresh(Animation animation)
	{
		if (_current != string.Empty)
		{
			string animName = AnimationAssisstant.Alias(_current, animation);
			AnimationState animState = animation[animName];
			if (animState != null)
			{
				float playTime = animState.time;
				animation.Play(animName);
				animState.time = playTime;
			}
		}
		else
		{
			if (_default != string.Empty)
			{
				string animName = AnimationAssisstant.Alias(_default, animation);
				AnimationState animState = animation[animName];
				if (animState != null)
				{
					float playTime = animState.time;
					animation.Play(animName);
					animState.time = playTime;
				}
				_current = _default;
			}
		}
	}

	string _current = string.Empty;
	string _default = string.Empty;
}


public class MoveAnimMixer
{
	public void SetMixNode(Animation animation, Transform node)
	{
		_mixTran = node;
		if (_active)
		{
			UpdateMix(animation);
		}
	}
	public void SetActive(Animation animation, bool active)
	{
		if (_active != active)
		{
			_active = active;
			UpdateMix(animation);
		}
	}

	public void UpdateMix(Animation animation)
	{
		if (animation == null || _mixTran == null)
		{
			return;
		}
		if (_active)
		{
			for (int iter = 0; iter < AnimationData.MoveMixAnims.Count; ++iter)
			{
				string animName = AnimationData.MoveMixAnims[iter];
				AnimationState animState = animation[animName];
				if (animState)
				{
					animState.AddMixingTransform(_mixTran);
				}
			}
		}
		else
		{
			for (int iter = 0; iter < AnimationData.MoveMixAnims.Count; ++iter)
			{
				string animName = AnimationData.MoveMixAnims[iter];
				AnimationState animState = animation[animName];
				if (animState)
				{
					animState.RemoveMixingTransform(_mixTran);
				}
			}
		}
	}

	Transform _mixTran;
	bool _active = false;
}

public class AnimationController
{
	public static void SetSpeed(Animation animation, float speed)
	{
		foreach (AnimationState state in animation)
		{
			state.speed = speed;
		}
	}

	public AnimationLoopLayer MoveLayer { get { return _moveLayer; } }
	public AnimationLoopLayer StateLayer { get { return _stateLayer; } }
	public AnimationLoopLayer DieLayer { get { return _dieLayer; } }

	public float DefaultSpeed { get { return _defaultSpeed; } set { _defaultSpeed = value; } }

	public void SynchronizeTo(AnimationController controller, Animation animation)
	{
		MoveLayer.SynchronizeTo(controller.MoveLayer, animation);
		StateLayer.SynchronizeTo(controller.StateLayer, animation);
		DieLayer.SynchronizeTo(controller.DieLayer, animation);
	}

	public void Start(Animation animation, bool blend)
	{
		animation.playAutomatically = false;
		MoveLayer.Start(animation, blend);
		StateLayer.Start(animation, blend);
		DieLayer.Start(animation, blend);
	}

	public void Revert(Animation animation)
	{
		MoveLayer.Revert(animation);
		StateLayer.Revert(animation);
		DieLayer.Revert(animation);
	}

	public void SetDefaultSpeed(Animation animation, float speed)
	{
		SetSpeed(animation, speed);
		_defaultSpeed = speed;
	}

	public void Play(Animation animation, string name, bool breakCurrent)
	{
		if (animation == null)
		{
			return;
		}
		if (_defaultSpeed <= 0)
		{
			return;
		}
		AnimationAssisstant.PlayerEx(animation, name, breakCurrent);
	}
	public void Play(Animation animation, string name, float startTime, bool blend)
	{
		if (animation == null)
		{
			return;
		}
		if (_defaultSpeed <= 0)
		{
			return;
		}
		string animName = AnimationAssisstant.Alias(name, animation);
		AnimationState animState = animation[animName];
		if (animState != null)
		{
			AnimationAssisstant.CrossFadeEx(animation, animName, blend);
			animState.normalizedTime = startTime;
		}
	}
	public void Stop(Animation animation, string name)
	{
		if (animation == null)
		{
			return;
		}
		animation.Stop(name);
	}
	public void Blend(Animation animation, string name)
	{
		if (animation == null)
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState != null)
		{
			if (animation.IsPlaying(name))
			{
				//animation.Rewind(name);
			}
			else
			{
				animation.Play(name);
			}
		}
	}
	public void SetSpeed(string name, float spd, Animation animation)
	{
		AnimationState animState = animation[name];
		if (animState == null)
		{
			return;
		}
		animState.speed = spd * DefaultSpeed;
	}

	public void SetPosition(string name, float time, Animation animation)
	{
		if (animation == null)
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState == null)
		{
			return;
		}
		animState.normalizedTime = time;
	}
	public void StartPosition(string name, Animation animation)
	{
		if (animation == null)
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState == null)
		{
			return;
		}
		animState.enabled = true;
		animState.weight = 1.0f;
		animState.speed = 0.0f;
	}
	public void EndPosition(string name, Animation animation)
	{
		if (animation == null)
		{
			return;
		}
		AnimationState animState = animation[name];
		if (animState == null)
		{
			return;
		}
		animState.weight = 0.0f;
		animState.enabled = false;
	}

	public bool GetAnimationTime(string name, Animation animation, out float time)
	{
		if (animation == null)
		{
			time = 0.0f;
			return false;
		}
		AnimationState animState = animation[name];
		if (animState == null)
		{
			time = 0.0f;
			return false;
		}
		if (animState.enabled == false)
		{
			time = 0.0f;
			return false;
		}
		time = animState.normalizedTime;
		return true;
	}

	AnimationLoopLayer _moveLayer = new AnimationLoopLayer();
	AnimationLoopLayer _stateLayer = new AnimationLoopLayer();
	AnimationLoopLayer _dieLayer = new AnimationLoopLayer();
	float _defaultSpeed = 1.0f;
}