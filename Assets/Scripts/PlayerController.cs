using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

    public float Speed = 2;

    public float TurnSpeed = 5;

    public Transform Mesh;

	public VirtualJoystick joystick;

	public bool isPauseGame;

    Transform t;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		this.enabled = false;
        t = transform;
        t.eulerAngles = new Vector3(0,90,0);
        orientation = 1;
    }
	
	// Update is called once per frame
	void Update () {
		if (!isPauseGame) {
			AxisMovement();
		}
      

    }

    float axis;
    float orientation;
    float lastAxis = 0;
	Vector3 nextPos;
    float orr = 0.025f;

    void AxisMovement()
    {
		axis = joystick.Horizontal ();

        //??? fix
        if(axis < -0.8f )
        {
            axis = -0.8f;
        }

        if ( axis > 0.8f)
        {
            axis = 0.8f;
        }

        if (axis == 0 )
        {
            lastAxis = axis;
            orientation = 0;
            return;
        }


        if (axis < lastAxis)
        {
            if(Mathf.Abs(axis - lastAxis) > orr)
            orientation = 1;
        }

        if (axis > lastAxis)
        {
            if (Mathf.Abs(axis - lastAxis) > orr)
                orientation = -1;
        }

        lastAxis = axis;

        if (orientation == 1)
        {
            Mesh.localRotation = Quaternion.Lerp(Mesh.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * TurnSpeed * 1 / Time.timeScale);
            nextPos = t.position + (t.forward * Time.deltaTime * Speed);
            if (nextPos.x < 1.1f)
                t.position = nextPos;
        }

        if (orientation == -1)
        {
            Mesh.localRotation = Quaternion.Lerp(Mesh.localRotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * TurnSpeed * 1 / Time.timeScale);
            nextPos = t.position - (t.forward * Time.deltaTime * Speed);
            if (nextPos.x > -.8f)
                t.position = nextPos;
        }


    }
}
