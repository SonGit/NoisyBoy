using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : State {

	public GameObject[] MusicBtns;
	public GameObject[] SoundBtns;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUISetting ();
	}

	public void MusicOn()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		DataController.instance.SubmitMusicSetting ("f");
	}

	public void MusicOff()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		DataController.instance.SubmitMusicSetting ("t");
	}

	public void SoundOn()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		DataController.instance.SubmitSoundSetting ("f");
	}

	public void SoundOff()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		DataController.instance.SubmitSoundSetting ("t");
	}

	public void Show()
	{
		gameObject.SetActive (true);
	}

	public void Hide()
	{
		gameObject.SetActive (false);
	}

	void UpdateUISetting()
	{
		UISound ();
		UIMusic ();
	}

	void UISound ()
	{
		if (DataController.instance.GetSoundSetting () == "t") 
		{
			SoundBtns [0].SetActive (true);
			SoundBtns [1].SetActive (false);
		}

		if (DataController.instance.GetSoundSetting () == "f")
		{
			SoundBtns [0].SetActive (false);
			SoundBtns [1].SetActive (true);
		}
	}


	void UIMusic ()
	{
		if (DataController.instance.GetMusicSetting () == "t") 
		{
			MusicBtns [0].SetActive (true);
			MusicBtns [1].SetActive (false);
		}

		if (DataController.instance.GetMusicSetting () == "f")
		{
			MusicBtns [0].SetActive (false);
			MusicBtns [1].SetActive (true);
		}
	}

	public override void Enter ()
	{

		if (GameManager.instance != null) {
			GameManager.instance.objScore.SetActive (false);
		}

		if (GameManager.instance != null) {
			GameManager.instance.objHighScore.SetActive (false);
		}

		gameObject.SetActive (true);
	}

	public override void Exit ()
	{
		if (GameManager.instance != null) {
			GameManager.instance.objScore.SetActive (false);
		}

		if (GameManager.instance != null) {
			GameManager.instance.objHighScore.SetActive (false);
		}

		gameObject.SetActive (false);
	}

}
