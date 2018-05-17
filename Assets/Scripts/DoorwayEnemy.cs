using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayEnemy : Enemy {

	public float Speed;
	public float TurnSpeed;

	private Transform t;

	// Use this for initialization
	void Start () {
		t = transform;
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V))
		{
			this.Attack ();
		}
	}


	public override void Attack ()
	{
		StartCoroutine(AttackSequence());
	}

	public override void AttackEvent ()
	{
		Spawner.instance.SpawnThrow (PosAttack);
	}

	IEnumerator AttackSequence()
	{
		Spawner.instance.isSpawnDoorwayEnemy = false;
		Doorway doorway = (Doorway)testDoor;
		testDoor.Open ();
		t.position = doorway.DoorStartPoint.position;

		yield return StartCoroutine(MoveToPos(doorway.DoorEndPoint.position));

		animator.SetTrigger("Attack");
		yield return new WaitForSeconds(2);

		yield return StartCoroutine(MoveToPos(doorway.DoorStartPoint.position));
		testDoor.Close();
		yield return new WaitForSeconds(1);
		Spawner.instance.isSpawnDoorwayEnemy = true;
		Spawner.instance.StartSpawnSpawnDoorwayEnemy ();
	}

	IEnumerator MoveToPos(Vector3 des)
	{
		float distance = Vector3.Distance(t.position, des);

		animator.SetBool("Walk", true);
		while (distance > .025f)
		{
			Vector3 targetDir = des - transform.position;
			// The step size is equal to speed times frame time.
			float step = TurnSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

			transform.rotation = Quaternion.LookRotation(newDir);

			distance = Vector3.Distance(t.position, des);
			t.position = Vector3.Lerp(t.position, des, Time.deltaTime * Speed);
			yield return new WaitForEndOfFrame();
		}
		animator.SetBool("Walk", false);
	}



}
