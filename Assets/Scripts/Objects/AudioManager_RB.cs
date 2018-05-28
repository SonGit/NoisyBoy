using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_RB : MonoBehaviour {

	public static AudioManager_RB instance;

	private Dictionary<SoundFX,AudioClip> clips;

	[HideInInspector]
	public string isOnSound = "t";

	void Awake()
	{
		instance = this;
	}

	IEnumerator Start()
	{
		

		clips = new Dictionary<SoundFX, AudioClip> {

			{ SoundFX.None, null },
			{ SoundFX.pickup, Resources.Load<AudioClip>("Sounds/pickup") },
			{ SoundFX.hitSound, Resources.Load<AudioClip>("Sounds/hitSound") },
			{ SoundFX.PlayerDeath, Resources.Load<AudioClip>("Sounds/PlayerDeath") },
			{ SoundFX.ButtonPresses, Resources.Load<AudioClip>("Sounds/ButtonPresses") },
			{ SoundFX.Whoosh, Resources.Load<AudioClip>("Sounds/Whoosh") },
			{ SoundFX.bup, Resources.Load<AudioClip>("Sounds/bup") },
			{ SoundFX.Sandal, Resources.Load<AudioClip>("Sounds/Sandal") },
			{ SoundFX.Pot, Resources.Load<AudioClip>("Sounds/Pot") },
		};

		yield return new WaitForSeconds (1);
	}

	public enum SoundFX
	{
		None,
		hitSound,
		PlayerDeath,
		ButtonPresses,
		pickup,
		Whoosh,
		bup,
		Sandal,
		Pot
	}

	public void PlayClip(SoundFX soundFX,Vector3 worldPos)
	{
		AudioClip clip;
		if (clips.TryGetValue (soundFX, out clip)) {
			
			AudioSource_RB audio = ObjectPool.instance.GetAudioSource ();
			audio.audioSource.clip = clip;

			if (isOnSound == "t") {
				audio.audioSource.volume = 1f;
			} else if (isOnSound == "f"){
				audio.audioSource.volume = 0;
			}
		
			audio.transform.position = worldPos;
			audio.Live ();

		}
	}
}
