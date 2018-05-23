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
		

		DontDestroyOnLoad (gameObject);

		clips = new Dictionary<SoundFX, AudioClip> {

			{ SoundFX.None, null },
//			{ SoundFX.Click, Resources.Load<AudioClip>("Sounds/Click") },
//			{ SoundFX.PlayerHurt, Resources.Load<AudioClip>("Sounds/PlayerHurt") },
//			{ SoundFX.EnemyHit, Resources.Load<AudioClip>("Sounds/EnemyHit") },
//			{ SoundFX.PlayerDeath, Resources.Load<AudioClip>("Sounds/PlayerDeath") },
//			{ SoundFX.ButtonPresses, Resources.Load<AudioClip>("Sounds/ButtonPresses") },
		};

		yield return new WaitForSeconds (1);
	}

	public enum SoundFX
	{
		None,
		Click,
		PlayerHurt,
		EnemyHit,
		PlayerDeath,
		ButtonPresses
	}

	public void PlayClip(SoundFX soundFX,Vector3 worldPos)
	{
		AudioClip clip;
		if (clips.TryGetValue (soundFX, out clip)) {
			
			AudioSource_RB audio = ObjectPoolSound.instance.GetAudioSource ();
			audio.audioSource.clip = clip;

			if (isOnSound == "t") {
				audio.audioSource.volume = 1;
			} else if (isOnSound == "f"){
				audio.audioSource.volume = 0;
			}
		
			audio.transform.position = worldPos;
			audio.Live ();

		}
	}
}
