using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Door testDoor;

    Animator animator;

    Transform t;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        t = transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack(testDoor);
        }
    }

    public void Attack(Door door)
    {
        StartCoroutine(AttackSequence(door));
    }

    IEnumerator AttackSequence(Door door)
    {
        door.Open();
        t.position = door.DoorStartPoint.position;
        yield return StartCoroutine(MoveToPos(door.DoorEndPoint.position));

    }

    IEnumerator MoveToPos(Vector3 des)
    {
        float distance = Vector3.Distance(t.position,des);

        while (distance > .1f)
        {
            distance = Vector3.Distance(t.position, des);
            t.position = Vector3.Lerp(t.position, des, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }
    }

}
