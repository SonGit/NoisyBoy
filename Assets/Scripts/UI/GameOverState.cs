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

	public bool isAds;

	public float countDownTime = 10;

	public bool isCountdown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CountDown ();
	}

	public override string GetName ()
	{
		return "GameOver";
	}

	public override void Enter (State from)
	{
		Invoke ("LoadGameOver", 0.7f);
			
		if (!isAds) {
			PlayCountDown ();
		}
	}

	public override void Exit (State to)
	{
		gameObject.SetActive (false);

	}
		
	private void LoadGameOver ()
	{
		gameObject.SetActive (true);
		isCountdown = true;
		MusicThemeManager.instance.StopMusic (0);
		MusicThemeManager.instance.StopMusic (3);
		MusicThemeManager.instance.StopMusic (4);
		MusicThemeManager.instance.StopMusic (5);
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
		MusicThemeManager.instance.OnMusic (2);
	}

	public void StopCountDown ()
	{
		isCountdown = false;
		MusicThemeManager.instance.StopMusic (2);
		countDownTime = -1f;
	}

	private void PlayMusicGameOver ()
	{
		if (Player.instance.currentLife <= 0) {
			MusicThemeManager.instance.OnMusic (1);
		}

	}

	public void StopMusicGameOver ()
	{
		MusicThemeManager.instance.StopMusic (1);
	}

}