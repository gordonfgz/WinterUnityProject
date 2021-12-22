using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAngleController : MonoBehaviour
{
    public float LockAngle(float curAngle, LockAngles lockAngles)
    {
        if (curAngle > lockAngles.maxAngle)
            curAngle = lockAngles.maxAngle;
        else if (curAngle < lockAngles.minAngle)
            curAngle = lockAngles.minAngle;
        return curAngle;
    }
}

