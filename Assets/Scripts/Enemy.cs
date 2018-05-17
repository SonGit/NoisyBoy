using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Cacheable
{
	protected Animator animator;

    public float TurnSpeed;

    public float Speed;

    private Transform t;

    // Use this for initialization
    public void Start()
    {
        animator = this.GetComponent<Animator>();
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	public abstract void Attack (Door door);
	public abstract void AttackEvent ();

    public IEnumerator MoveToPos(Vector3 des)
    {
        if(animator == null)
        {
            animator = this.GetComponent<Animator>();
        }
        if (t == null)
        {
            t = transform;
        }

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

    public override void OnLive()
    {
        gameObject.SetActive(true);

    }

    public override void OnDestroy()
    {
        transform.eulerAngles = Vector3.zero;
        gameObject.SetActive(false);
    }
}
