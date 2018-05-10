using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Transform DoorMesh;

    public Transform DoorStartPoint;

    public Transform DoorEndPoint;

    public float Speed;

	// Use this for initialization
	void Start () {
        targetRot = Quaternion.Euler(0, 0, 0);
    }
    Quaternion targetRot;
    // Update is called once per frame
    void Update () {

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

    public void Open()
    {
        targetRot = Quaternion.Euler(0, -90, 0);
    }

    public void Close()
    {
        targetRot = Quaternion.Euler(0, 0, 0);
    }


}
