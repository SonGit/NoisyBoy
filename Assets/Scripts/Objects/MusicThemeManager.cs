using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicThemeManager : MonoBehaviour {

	public static MusicThemeManager instance;

	[System.Serializable]
	public class Stem
	{
		public AudioSource source;
		public AudioClip clip;
	}

	public Stem[] stems;
	[HideInInspector]
	public string isOnMusic = "t";

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		stems [0].source.clip = stems [0].clip;
		stems [0].source.Play ();

	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < MusicThemeManager.instance.stems.Length; i++) {
			if (isOnMusic == "f") {
				MusicThemeManager.instance.stems [i].source.volume = 0;
			} else if (isOnMusic == "t"){
				MusicThemeManager.instance.stems [i].source.volume = 0.5f;
			}
		}
	}

	public void PlayMusicMenuVsGamePLay ()
	{
		stems[0].source.clip = MusicThemeManager.instance.stems[0].clip;
		stems [0].source.Play ();
	}

	public void PlayMusicCountDown ()
	{
		stems[2].source.clip = MusicThemeManager.instance.stems[2].clip;
		stems [2].source.Play ();
	}

	public void StopMusicCountDown ()
	{
		stems[2].source.clip = MusicThemeManager.instance.stems[2].clip;
		stems [2].source.Stop ();
	}

	public void PlayMusicGameOver ()
	{
		stems [1].source.clip = MusicThemeManager.instance.stems [1].clip;
		stems [1].source.Play ();
	}
		
}
