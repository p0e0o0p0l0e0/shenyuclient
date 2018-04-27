using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour {


    public float delayTime = 1.0f;
    bool isDelay = false;
	// Use this for initialization
	void Start ()
    {
        
    }

    void DelayFunc()
    {
        isDelay = true;
        gameObject.SetActive(true);
    }
	

    void OnEnable()
    {
        if (!isDelay)
        {
            gameObject.SetActive(false);
            Invoke("DelayFunc", delayTime);
        }
    }

    void OnDisable()
    {
        isDelay = false;
    }
}
