using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : Door {

    public Transform leftDoor;

    public Transform rightDoor;

    public Transform startPoint;

    // Update is called once per frame
    void Update () {
        if (!isFree)
        {
            leftDoor.localRotation = Quaternion.Lerp(leftDoor.localRotation, Quaternion.Inverse(targetRot), Time.deltaTime * Speed);
            rightDoor.localRotation = Quaternion.Lerp(rightDoor.localRotation, targetRot, Time.deltaTime * Speed);
        }
           
    }

    public override void Open()
    {
        targetRot = Quaternion.Euler(0, -140, 0);
    }

    public override void Close()
    {
        targetRot = Quaternion.Euler(0, 0, 0);
    }
}
