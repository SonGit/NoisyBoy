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
		PlayMusicMenu ();
		PlayMusicCar ();
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < stems.Length; i++) {
			if (isOnMusic == "f") {
				stems [i].source.volume = 0;
			} else if (isOnMusic == "t"){
				stems [i].source.volume = 0.6f;
			}
		}
	}

	public void PlayMusicMenu ()
	{
		stems[0].source.clip = stems[0].clip;
		stems [0].source.Play ();
	}

	public void PlayMusicCar ()
	{
		stems[3].source.clip = stems[3].clip;
		stems [3].source.Play ();
	}

	public void StopMusicCar ()
	{
		stems[3].source.clip = stems[3].clip;
		stems [3].source.Stop ();
	}

	public void PlayMusicTrumpet ()
	{
		stems[4].source.clip = stems[4].clip;
		stems [4].source.Play ();
	}

	public void StopMusicTrumpet ()
	{
		stems[4].source.clip = stems[4].clip;
		stems [4].source.Stop ();
	}

	public void PlayMusicCountDown ()
	{
		stems[2].source.clip = stems[2].clip;
		stems [2].source.Play ();
	}

	public void StopMusicCountDown ()
	{
		
		stems[2].source.clip = stems[2].clip;
		stems [2].source.Stop ();
	}

	public void PlayMusicGameOver ()
	{
		stems [1].source.clip = stems [1].clip;
		stems [1].source.Play ();
	}

	public IEnumerator PauseMusicTrumpet ()
	{
		StopMusicTrumpet ();
		yield return new WaitForSeconds (0.5f);
		PlayMusicTrumpet ();
	}
		
}
