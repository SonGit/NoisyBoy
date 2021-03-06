﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State {

	public GameObject[] containerBtns;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override string GetName ()
	{
		return "GamePLay";
	}

	public override void Enter (State from)
	{
		gameObject.SetActive (true);
		RedEnemyTower.instance.StartSpawn ();
		EnemyManager.instance.enabled = true;
		PlayerController.instance.enabled = true;
		GameManager.instance.objScore.SetActive (true);
		MusicThemeManager.instance.OnMusic (3);
		MusicThemeManager.instance.OnMusic (4);
	}

	public override void Exit (State to)
	{
		gameObject.SetActive (false);
		RedEnemyTower.instance.PauseSpawn ();
		EnemyManager.instance.enabled = false;
		PlayerController.instance.enabled = false;
	}

	public void PauseBtn ()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		PlayerController.instance.isPauseGame = true;
		Time.timeScale = 0;
		containerBtns [0].SetActive (false);
		containerBtns [1].SetActive (true);
	}

	public void ResumeBtn ()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		PlayerController.instance.isPauseGame = false;
		Time.timeScale = 1;
		containerBtns [0].SetActive (true);
		containerBtns [1].SetActive (false);
	}
}
