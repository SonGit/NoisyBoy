using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;

    public float TurnSpeed;

    public Door testDoor;

    Animator animator;

    Transform t;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
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

        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(2);

        yield return StartCoroutine(MoveToPos(door.DoorStartPoint.position));
        door.Close();
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
