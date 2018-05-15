using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 2;

    public float TurnSpeed = 5;

    public Transform Mesh;

    Transform t;

	// Use this for initialization
	void Start () {
        t = transform;
        t.eulerAngles = new Vector3(0,90,0);
        orientation = 1;
    }
	
	// Update is called once per frame
	void Update () {
        AxisMovement();

    }

    float axis;
    float orientation;
    void AxisMovement()
    {
        axis = Input.GetAxis("Horizontal");
        if(axis != 0)
        {
            if (axis < 0)
            {
                t.position += t.forward * Time.deltaTime * Speed * 1 / Time.timeScale;
                orientation = 1;
            }
            else
            {
                orientation = -1;
                t.position -= t.forward * Time.deltaTime * Speed * 1 / Time.timeScale;
            }
        }

        if (orientation > 0)
        {
            Mesh.localRotation = Quaternion.Lerp(Mesh.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * TurnSpeed * 1 / Time.timeScale);
        }
        else
        {
            Mesh.localRotation = Quaternion.Lerp(Mesh.localRotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * TurnSpeed * 1 / Time.timeScale);
        }

    }
}
