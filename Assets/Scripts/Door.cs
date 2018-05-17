using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour {

    public Transform DoorMesh;

    public float Speed;

    public bool isFree;

    protected Quaternion targetRot;

	// Use this for initialization
	protected void Start () {
        targetRot = Quaternion.Euler(0, 0, 0);
        isFree = true;
    }
    Quaternion rotation;
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
        if(!isFree)
        DoorMesh.localRotation = Quaternion.Lerp(DoorMesh.localRotation, targetRot, Time.deltaTime * Speed);
    }

	public abstract void Open ();
  
	public abstract void Close ();
  

}
