using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public static Spawner instance;

	public float rateWindowEnemyAttack;
	public float rateDoorwayEnemyAttack;
	public List<WindowEnemy> windowEnemy = new List<WindowEnemy> ();
	public List<DoorwayEnemy> doorwayEnemy = new List<DoorwayEnemy> ();

	private float ratetimeCount = 0;

	public bool isSpawnWindowEnemy;
	public bool isSpawnDoorwayEnemy;
	public Vector3 posPlayer;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		rateWindowEnemyAttack = Random.Range (0f, 4f);
		rateDoorwayEnemyAttack = Random.Range (6f, 8f);
		StartSpawnWindowEnemy ();
		StartSpawnSpawnDoorwayEnemy ();
	}

	void Update ()
	{
		ratetimeCount += Time.deltaTime;
		if (ratetimeCount > 4f)
		{
			ratetimeCount = 0f;
			rateWindowEnemyAttack = Random.Range (4f, 6f);
			rateDoorwayEnemyAttack = Random.Range (6f, 8f);
		}


			
	}

	public void StartSpawnWindowEnemy ()
	{
		StartCoroutine (SpawnWindowEnemy());
	}

	public void StartSpawnSpawnDoorwayEnemy ()
	{
		StartCoroutine (SpawnDoorwayEnemy());
	}
		
	public void SpawnThrow(Transform posThorw)
	{
		Sandal sandal = ObjectPool.instance.GetSandal ();
		Vector3 pos = posThorw.position;
		sandal.transform.position = pos;
		sandal.Live ();
	}


	public int rand = 10;
	public float dem = 0;

	IEnumerator SpawnWindowEnemy()
	{
		isSpawnWindowEnemy = true;
		while (isSpawnWindowEnemy) 
		{
			
			int m = Random.Range(1,8);

			for (int i = 0; i < m; i++) 
			{
				int tamp = rand;
				rand = Random.Range (0, windowEnemy.Count);

				WindowEnemy randWindowEnemy = windowEnemy [rand];
				posPlayer = randWindowEnemy.transform.position;
				dem++;
				yield return new WaitForSeconds (1.5f);

				if (rand != tamp) {
					randWindowEnemy.Attack ();

				} else {
					rand = Random.Range (tamp + (int)1f, windowEnemy.Count);
					dem -= 1f;
				}

				m -= 2;

			}
			isSpawnWindowEnemy = false;


		}
			

	}

	IEnumerator SpawnDoorwayEnemy()
	{
		isSpawnDoorwayEnemy = true;
		while (isSpawnDoorwayEnemy) {
			DoorwayEnemy randDoorwayEnemy = doorwayEnemy [Random.Range (0, doorwayEnemy.Count)];
			yield return new WaitForSeconds (rateDoorwayEnemyAttack);
			randDoorwayEnemy.Attack ();
		}

	}


}
