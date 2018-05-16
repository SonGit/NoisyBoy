using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public static Spawner instance;

	public float rateThrow;
	public float rateWindowEnemyAttack;
	public float rateDoorwayEnemyAttack;
	public List<WindowEnemy> windowEnemy = new List<WindowEnemy> ();
	public List<DoorwayEnemy> doorwayEnemy = new List<DoorwayEnemy> ();

	private bool isSpawnEnemyAttack;

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
		StartCoroutine (SpawnEnemyAttack());
	}
		
	public void SpawnThrow(Transform posThorw)
	{
		ThrowObject throwObject = ObjectPool.instance.GetThrowObject ();
		Vector3 pos = posThorw.position;
		throwObject.transform.position = pos;
		throwObject.Live ();
	}

	IEnumerator SpawnEnemyAttack()
	{
		isSpawnEnemyAttack = true;
		while (isSpawnEnemyAttack) {
			WindowEnemy randWindowEnemy = windowEnemy [Random.Range (0, windowEnemy.Count)];
			DoorwayEnemy randDoorwayEnemy = doorwayEnemy [Random.Range (0, doorwayEnemy.Count)];
			yield return new WaitForSeconds (rateWindowEnemyAttack);
			randWindowEnemy.Attack ();
			yield return new WaitForSeconds (rateDoorwayEnemyAttack);
			randDoorwayEnemy.Attack ();
		}
	}


}
