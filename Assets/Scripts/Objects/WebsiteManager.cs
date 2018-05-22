using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebsiteManager : MonoBehaviour {

	private Button m_Button;
	// Use this for initialization
	void Start () {
		m_Button = GetComponent<Button>();
		if (m_Button) m_Button.onClick.AddListener(LinkToWebsite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LinkToWebsite ()
	{
		Application.OpenURL ("market://details?id=com.avr.planet");
		//AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}
}
