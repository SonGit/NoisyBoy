using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public Transform[] Wheels;

    public float WheelSpeed = 250f;

    public float Speed = 2;

    public bool isReady;

    public Car linkedCar;

    public AudioSource carpassSound;

    Vector3 orgPos;

    // Use this for initialization
    void Start () {
        orgPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isReady)
            return;
        WheelAnimation();
        Move();
        CheckBoundaries();
    }

    void WheelAnimation()
    {
        for(int i = 0; i < Wheels.Length; i ++)
        {
            Wheels[i].Rotate(Vector3.right * Time.deltaTime * WheelSpeed); 
        }
    }

    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    bool playSoundPass;

    void CheckBoundaries()
    {
        if (transform.position.x > -3 && transform.position.x < 3)
        {
            isReady = true;
        }else
        {
            transform.position = orgPos;
            isReady = false;
            linkedCar.isReady = true;
            playSoundPass = false;
            carpassSound.Play();
        }

        if(!playSoundPass)
        if(transform.position.x > -0.3f && transform.position.x < 0.3f)
        {
                //carpassSound.Play();
                playSoundPass = true;
        }
    }


    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0);
        isReady = true;
    }
}
