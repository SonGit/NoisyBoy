using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : Cacheable {

    private Rigidbody rb;
    private TrailRenderer trailRenderer;

	public Vector3 target;

    public float h = 25;
    public float gravity = -18;

    public bool debugPath;

	public bool onEnable = false;

    public bool hasInit;

	public bool isKillPlayer;


    void OnEnable()
    {
		
    }

    void Update()
    {

        if (debugPath)
        {
            DrawPath();
        }
		
    }

    void Init()
    {
        rb = this.GetComponent<Rigidbody>();
        trailRenderer = this.GetComponentInChildren<TrailRenderer>();
        rb.useGravity = false;
        onEnable = true;
        hasInit = true;

    }
		

    public void Launch(Vector3 target)
    {
        if(!hasInit)
        {
            Init();
        }

        this.target = target;
        Physics.gravity = Vector3.up * gravity;
        rb.useGravity = true;
        rb.velocity = CalculateLaunchData().initialVelocity;

        trailRenderer.enabled = true;

		isKillPlayer = true;
    }

    ThrowObject otherObj;
    void OnCollisionEnter(Collision collision)
    {
		if (Player.instance.CheckIfAPlayer (collision.transform)) {
			Player.instance.OnHitThrowObj (GetComponent<ThrowObject> ());
		} else {

            otherObj = collision.transform.GetComponent<ThrowObject>();

            //if hit by another throw obj
            if(otherObj != null)
            {

            }
            else
            {
                isKillPlayer = false;
                trailRenderer.enabled = false;
                //Invoke ("StartPoofEffect",5);
                StartCoroutine(StartPoofEffect());
            }
		}
    }

    LaunchData CalculateLaunchData()
    {
        float displacementY = target.y - rb.position.y;
        Vector3 displacementXZ = new Vector3(target.x - rb.position.x, 0, target.z - rb.position.z);
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawPoint = rb.position;

        int resolution = 30;
        for (int i = 1; i <= resolution; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = rb.position + displacement;
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }

    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }

    }

    public override void OnLive()
    {
        if (trailRenderer != null)
            trailRenderer.Clear();
        transform.position = new Vector3(999, 999, 999);

        gameObject.SetActive(true);
    }

    public override void OnDestroy()
    {
        if (trailRenderer != null)
            trailRenderer.Clear();
        gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void PickedUp()
    {
        PickupParticle pickupParticle = ObjectPool.instance.GetPickupParticle();
        pickupParticle.transform.position = new Vector3(transform.position.x, 0.153f, transform.position.z);
        trailRenderer.enabled = false;
        transform.position = new Vector3(999, 999, 999);
    }

    public void PoofEffect(Transform pos)
	{
		PoofEffect poofEffect = ObjectPool.instance.GetPoofEffect ();
		poofEffect.transform.position = pos.position;
		StartCoroutine (WaitDestroy());
	}

	IEnumerator StartPoofEffect ()
	{
		yield return new WaitForSeconds (4);
		PoofEffect (transform);
	}

	public void CFXM_Hit_GreenEffect(Transform pos)
	{
		CFXM_Hit_Green CFXM_Hit_Green = ObjectPool.instance.GetCFXM_Hit_Green ();
		CFXM_Hit_Green.transform.position = pos.position;
		CFXM_Hit_Green.Destroy ();
		StartCoroutine (WaitDestroy());
	}

	IEnumerator WaitDestroy ()
	{
		yield return new WaitForSeconds (0.06f);
		Destroy ();
	}

}
