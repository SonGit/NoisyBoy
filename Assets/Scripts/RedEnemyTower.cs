using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyTower : Enemy
{
    public Transform shootPoint;

    public float rateOfFire;

    // Use this for initialization
    void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        Attack(null);
    }
    // Update is called once per frame
    void Update () {
		
	}

    public override void Attack(Door door)
    {
        StartCoroutine(AttackSequence(door));
    }

    IEnumerator AttackSequence(Door door)
    {
        while(true)
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
        Vector3 pos = (transform.position + transform.forward * .4f);
        //sandalA.Launch(new Vector3(pos.x, 0.0565f, pos.z));
       // sandalA.Launch(Player.instance.transform.position);
		throwObj.Launch(Player.instance.transform.position);
    }
}
