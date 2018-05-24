using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverState : State {

	public static GameOverState instance;

	void Awake ()
	{
		instance = this;
	}

	public TextMeshProUGUI countDownText;
	public GameObject objGameOverText;
	public GameObject objAds;
	[HideInInspector]
	public bool isSetting;
	[HideInInspector]
	public bool isAds;

	public float countDownTime = 10;

	public bool isCountdown;

	// Use this for initialization
	void Start () {
		isSetting = false;
	}
	
	// Update is called once per frame
	void Update () {
		CountDown ();
	}

	public override void Enter ()
	{
		if (!isSetting) {
			Invoke ("ShowGameOver", 0.7f);
		} else {
			ShowGameOver ();
		}
			
		if (!isAds) {
			PlayCountDown ();
		}

		isCountdown = true;
	}

	public override void Exit ()
	{
		gameObject.SetActive (false);

	}
		
	private void ShowGameOver ()
	{
		gameObject.SetActive (true);
		MusicThemeManager.instance.StopMusicTrumpet ();
		MusicThemeManager.instance.StopMusicCar ();
		MusicThemeManager.instance.StopMusicMenu ();
		isSetting = false;
		//CancelInvoke ();
	}

	public void CountDown ()
	{
		if (!isCountdown) 
		{
			return;
		}

		countDownTime -= Time.deltaTime;

		if (countDownTime <= 0) {
			isCountdown = false;
			PlayMusicGameOver ();
			ObjAdsUnActive ();
		}
        if(countDownText !=null)
		countDownText.text = "" + (int)countDownTime;
	}

	public void ObjAdsUnActive ()
	{
		objAds.SetActive (false);
		objGameOverText.SetActive (true);
	}

	private void PlayCountDown ()
	{
		MusicThemeManager.instance.PlayMusicCountDown ();
	}

	public void StopCountDown ()
	{
		isCountdown = false;
		MusicThemeManager.instance.StopMusicCountDown ();
		countDownTime = -1f;
	}

	private void PlayMusicGameOver ()
	{
		
		if (Player.instance.currentLife <= 0) {
			MusicThemeManager.instance.PlayMusicGameOver ();
		}

	}

}