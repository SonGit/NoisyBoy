﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{

    public Transform shootPoint;

	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack(Door door)
    {
        StartCoroutine(AttackSequence(door));
    }

    public override void AttackEvent()
    {
        Sandal sandal = ObjectPool.instance.GetSandal();
        sandal.transform.position = shootPoint.position;
        sandal.Launch(transform.position + transform.forward * .4f);
    }

    IEnumerator AttackSequence(Door door)
    {
        door.isFree = false;

        if (door is Window)
        {
            Window window = door as Window;
            window.Open();

            transform.position = window.startPoint.position;

            yield return new WaitForSeconds(2.2f);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(2);

            window.Close();
        }

        if(door is Doorway)
        {
            Doorway doorway = door as Doorway;
            doorway.Open();

            transform.position = doorway.DoorStartPoint.position;
            yield return StartCoroutine(MoveToPos(doorway.DoorEndPoint.position));
            yield return new WaitForSeconds(1);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(2);
            yield return StartCoroutine(MoveToPos(doorway.DoorStartPoint.position));
            doorway.Close();
        }

        yield return new WaitForSeconds(1);
        door.isFree = true;
        Destroy();
    }
}
