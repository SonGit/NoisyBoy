using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyTower : Enemy
{
	public static RedEnemyTower instance;

    public Transform shootPoint;

    public float rateOfFire;

	public bool isSpawn;

	public RedEnemyTower[] redEnemyTower;

	GameObject[] gameObjects;

	void Awake ()
	{
		instance = this;
	}

    // Use this for initialization
    void Start()
    {
		isSpawn = false;

		gameObjects = GameObject.FindGameObjectsWithTag ("RedEnemyTower");
		redEnemyTower = new RedEnemyTower[gameObjects.Length];

        base.Start();
     
    }
    // Update is called once per frame
    void Update () {
		
	}

	public void StartSpawn ()
	{
		for (int i = 0; i < gameObjects.Length; i++) {
			redEnemyTower [i] = gameObjects [i].GetComponent<RedEnemyTower> ();
			redEnemyTower [i].isSpawn = true;
			redEnemyTower [i].Attack(null);
		}


	}

	public void PauseSpawn ()
	{
		for (int i = 0; i < gameObjects.Length; i++) {
			redEnemyTower [i] = gameObjects [i].GetComponent<RedEnemyTower> ();
			redEnemyTower [i].isSpawn = false;
		}
	}


    public override void Attack(Door door)
    {
        StartCoroutine(AttackSequence(door));
    }

    IEnumerator AttackSequence(Door door)
    {
		while(isSpawn)
        {
            yield return new WaitForSeconds(2.2f);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(rateOfFire);
        }
    }

    public override void AttackEvent()
    {
		ThrowObject throwObj;

		int rand = Random.Range (0,5);

		switch (rand) {
		case 0:
			throwObj = ObjectPool.instance.GetSandalA ();
			break;
		case 1:
			throwObj = ObjectPool.instance.GetSandalB ();
			break;
		case 2:
			throwObj = ObjectPool.instance.GetBread ();
			break;
		case 3:
			throwObj = ObjectPool.instance.GetHammer ();
			break;
		case 4:
			throwObj = ObjectPool.instance.GetPot ();
			break;
		default:
			throwObj = ObjectPool.instance.GetSandalA ();
			break;
		}


		throwObj.transform.position = shootPoint.position;
       // Vector3 pos = (transform.position + transform.forward * .4f);
        //sandalA.Launch(new Vector3(pos.x, 0.0565f, pos.z));
       // sandalA.Launch(Player.instance.transform.position);
		throwObj.Launch(Player.instance.transform.position);

		if (Player.instance.currentLife > 0) {
			AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.Whoosh,transform.position);
		}

    }
}
