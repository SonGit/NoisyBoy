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

    public float timeToPool;

    float timeToPoolCount;

    void Update()
    {

        if (debugPath)
        {
            DrawPath();
        }

        if(!isKillPlayer)
        {
            timeToPoolCount -= Time.deltaTime;

            if (timeToPoolCount <= 0)
            {
                PoofEffect();
            }
        }

    }

    void Init()
    {
        rb = this.GetComponent<Rigidbody>();
        trailRenderer = this.GetComponentInChildren<TrailRenderer>();
        rb.useGravity = false;
        onEnable = true;
        hasInit = true;
        timeToPool = 4;
        timeToPoolCount = timeToPool;
    }
		

    public void Launch(Vector3 target)
    {
        if(!hasInit)
        {
            Init();
        }

        this.target = target;
        timeToPoolCount = timeToPool;

        Physics.gravity = Vector3.up * gravity;
        rb.useGravity = true;

        isKillPlayer = true;

        rb.velocity = CalculateLaunchData().initialVelocity;

        trailRenderer.enabled = true;
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
        gameObject.SetActive(true);

        if (trailRenderer != null)
            trailRenderer.Clear();
        timeToPoolCount = 0;
    }

    public override void OnDestroy()
    {
        transform.position = Vector3.one * 999;
        gameObject.SetActive(false);
        if(trailRenderer != null)
            trailRenderer.Clear();
        timeToPoolCount = 0;
    }

    public void PickedUp()
    {
        PickupParticle pickupParticle = ObjectPool.instance.GetPickupParticle();
        pickupParticle.transform.position = new Vector3(transform.position.x, 0.153f, transform.position.z);

        Destroy();
    }

    public void PoofEffect()
	{
		PoofEffect poofEffect = ObjectPool.instance.GetPoofEffect ();
        poofEffect.transform.position = new Vector3(transform.position.x, 0.153f,transform.position.z);

        Destroy();
    }

	public void CFXM_Hit_GreenEffect(Transform pos)
	{
		CFXM_Hit_Green CFXM_Hit_Green = ObjectPool.instance.GetCFXM_Hit_Green ();
		CFXM_Hit_Green.transform.position = pos.position;
		CFXM_Hit_Green.Destroy ();

        Destroy();
    }
}
