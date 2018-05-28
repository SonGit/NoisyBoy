using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebsiteManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LinkToCroroll ()
	{
		Application.OpenURL ("market://details?id=com.avr.planet");
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}

	public void LinkToNoisyBoy ()
	{
		Application.OpenURL ("market://details?id=com.avr.NoisyBoyFunSurvival");
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}
}
