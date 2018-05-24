using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject objScore;
	public GameObject objHighScore;

	public State[] states;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		objScore.SetActive (false);
		objHighScore.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowGamePlay ()
	{
		for (int i = 0; i < states.Length; i++) {
			states [1].Enter ();
			states [0].Exit ();
		}
	}

	public void ShowGameOver ()
	{
		for (int i = 0; i < states.Length; i++) {
			states [2].Enter ();
			states [1].Exit ();
		}
	}

	public void HideGameOver ()
	{
		for (int i = 0; i < states.Length; i++) {
			states [2].Exit ();
			states [1].Enter ();
		}
	}

	public void ShowSetting ()
	{
		for (int i = 0; i < states.Length; i++) {
			states [3].Enter ();
			states [2].Exit ();
		}
	}

	public void HideSetting ()
	{
		for (int i = 0; i < states.Length; i++) {
			states [3].Exit ();
			states [2].Enter ();
		}
	}
		
	public void ReStartGame ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Player.Score = 0;
	}


}
