using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    public void ConditionalFlip(float angle, FlipOptions flipOptions)
    {
        if (angle >= -flipOptions.flipThreshold && angle <= flipOptions.flipThreshold)
            return;

        foreach (GameObject obj in flipOptions.partsToFlip)
        {
            Vector3 newAngle = (flipOptions.flipAxis == FlipOptions.FlipAxis.X_AXIS) ? new Vector3(flipOptions.flipTo, obj.transform.rotation.y, obj.transform.rotation.z)
                 : (flipOptions.flipAxis == FlipOptions.FlipAxis.Y_AXIS) ? new Vector3(obj.transform.rotation.x, flipOptions.flipTo, obj.transform.rotation.z)
                 : new Vector3(obj.transform.rotation.x, obj.transform.rotation.y, flipOptions.flipTo);

            Flip(obj, newAngle);
        }
    }

    public void Flip(GameObject obj, Vector3 angle)
    {
        obj.transform.rotation = Quaternion.Euler(angle);
        Debug.Log("Object: " + obj.name + " ,Rotation: " + obj.transform.eulerAngles);
    }
}
