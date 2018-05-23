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
	[HideInInspector]
	public float countDownTime = 10;
	[HideInInspector]
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
			StopCountDown ();
			PlayMusicGameOver ();
			ObjAdsUnActive ();
		}

		countDownText.text = "" + (int)countDownTime;
	}

	public void ObjAdsUnActive ()
	{
		objAds.SetActive (false);
		objGameOverText.SetActive (true);
	}

	private void PlayCountDown ()
	{
		//MusicThemeManager.instance.PlayMusicCountDown ();
	}

	private void StopCountDown ()
	{
		isCountdown = false;
		//MusicThemeManager.instance.StopMusicCountDown ();
	}

	private void PlayMusicGameOver ()
	{
//		if (Player.instance.currentLife <= 0) {
//			MusicThemeManager.instance.PlayMusicGameOver ();
//		}

	}

}