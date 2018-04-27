using UnityEngine;
using System.Collections;

public class DelayHide : MonoBehaviour
{
    public float delayTime = 1.0f;
    //bool isDelay = false;

    void OnEnable()
    {
        Invoke("DelayFunc", delayTime);
    }

    void OnDisable()
    {
       
    }

    void DelayFunc()
    {
        gameObject.SetActive(false);
    }

}
