﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Door {

	public bool left;

    public Transform startPoint;

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
			targetRot = Quaternion.Euler (0, -136, 0);
		} else {
			targetRot = Quaternion.Euler (0, -136, 0);
		}
	}

	public override void Close ()
	{
		targetRot = Quaternion.Euler(0, 0, 0);
	}
}
