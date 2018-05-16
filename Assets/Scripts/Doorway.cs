using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : Door {

	public Transform DoorStartPoint;
	public Transform DoorEndPoint;
	public bool left;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

	}

	public override void Open ()
	{
		if (left) {
			targetRot = Quaternion.Euler (0, -90, 0);
		} else {
			targetRot = Quaternion.Euler (0, 90, 0);
		}
	}

	public override void Close ()
	{
		targetRot = Quaternion.Euler(0, 0, 0);
	}
}
