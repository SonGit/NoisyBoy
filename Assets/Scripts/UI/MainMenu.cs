using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

//	public GameObject Main;
//	public GameObject Setting;
//	public GameObject Tutorial;
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	public void GoToMain()
//	{
//		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
//
//		if (Main != null) {
//			Main.SetActive (true);
//		}
//
//		if (Setting != null) {
//			Setting.SetActive (false);
//		}
//
//		if (Tutorial != null) {
//			Tutorial.SetActive (false);
//		}
//
//		if (GameManager.instance != null) {
//			GameManager.instance.objScore.SetActive (true);
//		}
//
//		if (GameManager.instance != null) {
//			GameManager.instance.objHighScore.SetActive (true);
//		}
//
//	}
//
//	public void GoToSetting()
//	{
//		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
//
//		if (Main != null) {
//			Main.SetActive (false);
//		}
//
//		if (Setting != null) {
//			Setting.SetActive (true);
//		}
//
//		if (GameManager.instance != null) {
//			GameManager.instance.objScore.SetActive (false);
//		}
//
//		if (GameManager.instance != null) {
//			GameManager.instance.objHighScore.SetActive (false);
//		}
//
//	}
//
//	public void GoToTutorial()
//	{
//		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
//
//		if (Main != null) {
//			Main.SetActive (false);
//		}
//
//		if (Tutorial != null) {
//			Tutorial.SetActive (true);
//		}
//
//		if (GameManager.instance != null) {
//			GameManager.instance.objScore.SetActive (false);
//		}
//
//		if (GameManager.instance != null) {
//			GameManager.instance.objHighScore.SetActive (false);
//		}
//
//	}


	public void LoadLevel ()
	{
		RedEnemyTower.instance.StartSpawn ();
		StartCoroutine (EnemyManager.instance.StartSpawn ());
		//AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
	}
}
