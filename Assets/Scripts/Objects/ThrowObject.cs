using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : Cacheable {

    private Rigidbody rb;
    private TrailRenderer trailRenderer;

    public Transform target;

    public float h = 25;
    public float gravity = -18;

    public bool debugPath;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        trailRenderer = this.GetComponentInChildren<TrailRenderer>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }

        if (debugPath)
        {
            DrawPath();
        }
    }

    void Launch()
    {
        if (target == null)
            return;

        Physics.gravity = Vector3.up * gravity;
        rb.useGravity = true;
        rb.velocity = CalculateLaunchData().initialVelocity;

        trailRenderer.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        trailRenderer.enabled = false;
    }

    LaunchData CalculateLaunchData()
    {
        float displacementY = target.position.y - rb.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - rb.position.x, 0, target.position.z - rb.position.z);
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

    }

    public override void OnDestroy()
    {
        gameObject.SetActive(false);
    }
}
