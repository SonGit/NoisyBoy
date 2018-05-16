using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	public Door testDoor;
	public Transform PosAttack;

	protected Animator animator;

  	
    // Use this for initialization
	public void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	public abstract void Attack ();
	public abstract void AttackEvent ();
}
