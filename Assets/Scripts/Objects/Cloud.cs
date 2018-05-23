using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public float speed;

    Vector3 initPos;

	// Use this for initialization
	void Start () {
        initPos = new Vector3(-2f,transform.position.y,transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * Time.deltaTime * speed;

        if(transform.position.x >1.7f)
        {
            transform.position = initPos;
            //speed += Random.Range(-100,100)/1000f;
            //if (speed < 0)
               // speed = 0.03f;
        }
	}
}
