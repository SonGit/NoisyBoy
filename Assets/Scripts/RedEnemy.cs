using System.Collections;
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
        //sandalA.Launch(transform.position + transform.forward * .4f);
		if (Player.instance.currentLife > 0) {
			AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.Whoosh,transform.position);
		}

        float distanceToPlayer = Vector3.Distance(transform.position,Player.instance.transform.position);

        if(distanceToPlayer > 0.85f)
        {
            Vector3 landingPos = transform.position + transform.forward * .4f;
            landingPos = new Vector3(landingPos.x, 0.0565f, landingPos.z);
            throwObj.Launch(landingPos);
        }
        else
        {
            throwObj.Launch(Player.instance.transform.position + new Vector3(Random.Range(-75, 75) / 100f, 0, 0));
        }
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

        if (door is DoubleDoor)
        {
            DoubleDoor doorway = door as DoubleDoor;
            doorway.Open();

            transform.position = doorway.startPoint.position;
            yield return new WaitForSeconds(1);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(2);
            doorway.Close();
        }

        yield return new WaitForSeconds(1);
        door.isFree = true;
        Destroy();
    }
}
