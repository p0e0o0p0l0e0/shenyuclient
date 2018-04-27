using UnityEngine;
using System.Collections;
//created by Jason 20160729
public class JasonReplay : MonoBehaviour {
	//public float playSpeed = 1.0f;
	[UnityEngine.Header("按空格键重播:)")]
	public float 播放速度 = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	void Update () {
		Time.timeScale = 播放速度;
		if(Input.GetKey(KeyCode.Space)){
			Jason ();
		}
	}

	public void Jason(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
