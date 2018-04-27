using UnityEngine;

public class FadeOutProperty : MonoBehaviour
{
	public float Duration = 1.0f;
	public float VerticalSpeed = -1.0f;
	public Transform[] ActiveObject;
	public Animation ActiveAnimation;
	public Animator ActiveAnimator;
	public Transform[] DeactiveObject;
	public Animation DeactiveAnimation;
	public Animator DeactiveAnimator;
	public ParticleSystem[] CloseParticle;

	public void Exec()
	{
		if (ActiveObject != null)
		{
			for (int iter = 0; iter < ActiveObject.Length; ++iter)
			{
				Transform iterTran = ActiveObject[iter];
				if (iterTran != null)
				{
					iterTran.gameObject.SetActive(true);
				}
			}
		}
		if (ActiveAnimation != null)
		{
			ActiveAnimation.Play();
		}
		if (ActiveAnimator != null)
		{
			ActiveAnimator.Play("");
		}
		//
		if (DeactiveObject != null)
		{
			for (int iter = 0; iter < DeactiveObject.Length; ++iter)
			{
				Transform iterTran = DeactiveObject[iter];
				if (iterTran != null)
				{
					iterTran.gameObject.SetActive(false);
				}
			}
		}
		if (DeactiveAnimation != null)
		{
			DeactiveAnimation.Stop();
		}
		if (DeactiveAnimator != null)
		{
			//DeactiveAnimator.Stop();
		}
		if (CloseParticle != null)
		{
			for (int iter = 0; iter < CloseParticle.Length; ++iter)
			{
				ParticleSystem iterParticle = CloseParticle[iter];
				if (iterParticle != null)
				{
					iterParticle.Stop(false);
				}
			}
		}
	}

	void OnEnable()
	{
		Exec();
	}

	void Update()
	{
		transform.Translate(Vector3.up * VerticalSpeed * Time.deltaTime);
	}
}