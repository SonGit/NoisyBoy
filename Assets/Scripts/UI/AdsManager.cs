using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

	public static AdsManager instance;

	private Button m_Button;
	private string gameId = "1792243";
	//private string placementId = "rewardedVideo";
	private string placementId = "rewardedVideo";
	[HideInInspector]
	public bool isAds;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{    
		m_Button = GetComponent<Button>();
		if (m_Button) m_Button.onClick.AddListener(ShowAd);

		//---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId, true);
		}

		//-------------------------------------------------------------------//

	}

	void Update ()
	{
		if (m_Button) m_Button.interactable = Advertisement.IsReady(placementId);
	}

	public void ShowAd ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);

		//AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}

	private void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			Rewardplayer();

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
			Rewardplayer();

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}

	private void Rewardplayer ()
	{
//		isAds = true;
//		Player.instance.currentLife ++;
//		GameManager.instance.HideGameOver ();
//		GameManager.instance.ObjAdsUnActive ();
//		GameManager.instance.gamePlayUI.SetActive (true);
//		GameManager.instance.objHighScore.SetActive (false);
//		Player.instance.PlayerUndying ();
//		EnemySpawner.instance.StartSpawn ();
//		PlayerController_RB.instance.enabled = true;
//		PlayerController_RB.instance.speed = PlayerController_RB.instance.startspeed;
//		Player.instance.isAddScorePerSecond = true;
//		MusicThemeManager.instance.PlayMusicMenuVsGamePLay ();
//		VirtualJoystick.instance.ImgAnchor.transform.position = new Vector3(-20000,-20000,-20000);
//		GameManager.instance.isCountdown = false;
//		GameManager.instance.countDownTime = -1f;
//		Planet.instance.GetComponent<Planet> ().enabled = true;

	}
		
}
