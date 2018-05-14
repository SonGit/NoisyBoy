using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSound : MonoBehaviour {

	public static ObjectPoolSound instance;

	GenericObject<AudioSource_RB> audioSource;

	void Awake()
	{
		instance = this;
	}
		
	// Use this for initialization
	void Start () {
		audioSource = new GenericObject<AudioSource_RB>(ObjectFactory.PrefabType.AudioSource,1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public AudioSource_RB GetAudioSource()
	{
		return audioSource.GetObj ();
	}
}
