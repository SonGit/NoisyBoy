using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Enter ()
	{
		gameObject.SetActive (true);
		RedEnemyTower.instance.StartSpawn ();
		EnemyManager.instance.enabled = true;
		PlayerController.instance.enabled = true;
		PlayerController.instance.joystick.gameObject.SetActive(true);
		GameManager.instance.objScore.SetActive (true);
	}

	public override void Exit ()
	{
		gameObject.SetActive (false);
		RedEnemyTower.instance.PauseSpawn ();
		EnemyManager.instance.enabled = false;
		PlayerController.instance.enabled = false;
		PlayerController.instance.joystick.gameObject.SetActive(false);
	}
}
