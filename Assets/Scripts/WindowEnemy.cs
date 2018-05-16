using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEnemy : Enemy {


	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
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
		Spawner.instance.SpawnThrow (transform);
	}



	IEnumerator AttackSequence()
	{
		testDoor.Open ();

		yield return new WaitForSeconds(2.2f);
		animator.SetTrigger("Attack");
		yield return new WaitForSeconds(2);

		testDoor.Close();
	}




}
