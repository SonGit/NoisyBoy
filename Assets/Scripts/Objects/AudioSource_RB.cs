using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource_RB : Cacheable {

	public AudioSource audioSource ;

	public override void OnLive ()
	{
		audioSource.Play();
	}

	public override void OnDestroy ()
	{

	}


	// Use this for initialization
	void Start () {
		Destroy ();
	}

	private float timeCount = 0;

	// Update is called once per frame
	void Update () {

		if (!_isInPool)
			return;

		timeCount += Time.deltaTime;

		if (timeCount > audioSource.clip.length) {
			timeCount = 0;
			Destroy ();
		}

	}

}
