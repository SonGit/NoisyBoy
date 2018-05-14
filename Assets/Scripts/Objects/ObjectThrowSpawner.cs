using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrowSpawner : MonoBehaviour {

	public static ObjectThrowSpawner instance;

	public float rate;

	public Transform[] spawnPoints;

	private bool isSpawn;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		StartSpawn ();
	}

	public void StartSpawn ()
	{
		StartCoroutine (Spawn());
	}
		
	IEnumerator Spawn()
	{
		isSpawn = true;
		while (isSpawn) {
			Transform randSpawnPoints = spawnPoints [Random.Range (0, spawnPoints.Length)];
			yield return new WaitForSeconds (rate);
			ThrowObject throwObject = ObjectPool.instance.GetThrowObject ();
			Vector3 pos = randSpawnPoints.position;
			throwObject.transform.position = pos;
			throwObject.Live ();
		}
	}


}
