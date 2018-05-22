using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;


	public GameObject gameOverUI;
	public GameObject gamePlayUI;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowGameOver ()
	{
		StartCoroutine (WaitShowGameOver());
	}

	private IEnumerator WaitShowGameOver ()
	{
		gamePlayUI.SetActive (false);

		yield return new WaitForSeconds (0.7f);
		gameOverUI.SetActive (true);
	}

	public void PauseGame ()
	{
		Time.timeScale = 0;
	}

}
