using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : State {

	public override string GetName ()
	{
		return "MainMenu";
	}

	public override void Enter (State from)
	{
		gameObject.SetActive (true);
	}

	public override void Exit (State to)
	{
		gameObject.SetActive (false);
	}


}
