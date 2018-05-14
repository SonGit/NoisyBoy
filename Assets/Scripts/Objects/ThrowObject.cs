using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : Cacheable {

	public float throwingForce;

	private Vector3 targetPosition;
	private Rigidbody rigidbodyThrowPrefabs;

	private GameObject player;
	private Vector3 dir;

	public override void OnLive ()
	{
		gameObject.SetActive (true);

	}

	public override void OnDestroy ()
	{
		gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		rigidbodyThrowPrefabs = GetComponent<Rigidbody> ();
		Destroy ();
	}

	void OnEnable ()
	{
		Throw (targetPosition);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {

		}

		rigidbodyThrowPrefabs.velocity = new Vector3 (dir.x,dir.y,dir.z) * throwingForce;

	}

	private void Throw (Vector3 targetPos)
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		targetPos = player.transform.position;
		dir = targetPos - transform.position;
	}


}
