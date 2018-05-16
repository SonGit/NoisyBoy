using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour {

    public Transform DoorMesh;

    public float Speed;

	protected Quaternion targetRot;

	// Use this for initialization
	protected void Start () {
        targetRot = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
	protected void Update () {

		if(Input.GetKeyDown(KeyCode.Z))
		{
			Open();
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			Close();
		}

        DoorMesh.localRotation = Quaternion.Lerp(DoorMesh.localRotation, targetRot, Time.deltaTime * Speed);

    }

	public abstract void Open ();
  
	public abstract void Close ();
  


}
