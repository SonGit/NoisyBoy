using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	public static DataController instance;

	private void Awake ()
	{
		if (instance == null) 
		{
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
//	// Update is called once per frame
//	void Update () {
//		LoadPlayerProgress ();
//		LoadSoundSettingProgress ();
//		LoadMusicSettingProgress ();
//	}
//
//	public void SubmitNewPlayerScore(int newScore)
//	{
//		if (newScore > Player.highScore) {
//			Player.highScore = newScore;
//			SavePlayerProgress ();
//		}
//	}
//
//	public float GetHighestPlayerScore ()
//	{
//		return Player.highScore;
//	}
//
//	public void LoadPlayerProgress ()
//	{
//		if (PlayerPrefs.HasKey ("HighestScore")) {
//			Player.highScore = PlayerPrefs.GetInt ("HighestScore");
//		}
//	}
//
//	private void SavePlayerProgress ()
//	{
//		PlayerPrefs.SetInt ("HighestScore", Player.highScore);
//	}
//
//	public void SubmitSoundSetting(string a)
//	{
//		AudioManager_RB.instance.isOnSound = a;
//		SaveSoundSettingProgress ();
//	}
//
//	public string GetSoundSetting ()
//	{
//		return AudioManager_RB.instance.isOnSound;
//
//	}
//
//	public void LoadSoundSettingProgress ()
//	{
//		if (PlayerPrefs.HasKey ("SettingSound")) {
//			AudioManager_RB.instance.isOnSound = PlayerPrefs.GetString ("SettingSound");
//		}
//	}
//
//	private void SaveSoundSettingProgress ()
//	{
//		PlayerPrefs.SetString ("SettingSound", AudioManager_RB.instance.isOnSound);
//	}
//
//
//	public void SubmitMusicSetting(string m)
//	{
//		MusicThemeManager.instance.isOnMusic = m;
//		SaveMusicSettingProgress ();
//	}
//
//	public string GetMusicSetting ()
//	{
//		return MusicThemeManager.instance.isOnMusic;
//	}
//
//	public void LoadMusicSettingProgress ()
//	{
//		if (PlayerPrefs.HasKey ("SettingMusic")) {
//			MusicThemeManager.instance.isOnMusic = PlayerPrefs.GetString ("SettingMusic");
//		}
//	}
//
//	private void SaveMusicSettingProgress ()
//	{
//		PlayerPrefs.SetString ("SettingMusic", MusicThemeManager.instance.isOnMusic);
//	}
}
