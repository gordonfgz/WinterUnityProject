using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlipController : MonoBehaviour
{
    public void ConditionalFlip(float angle, FlipOptions flipOptions)
    {
        float ogAngle;

        switch (flipOptions.flipAxis)
        {
            case FlipOptions.FlipAxis.X_AXIS:
                ogAngle = transform.position.x;
                break;
            case FlipOptions.FlipAxis.Y_AXIS:
                ogAngle = transform.position.y;
                break;
            case FlipOptions.FlipAxis.Z_AXIS:
                ogAngle = transform.position.z;
                break;
            default:
                ogAngle = transform.position.y;
                break;
        }

        float flipAngle = (angle < -flipOptions.flipThreshold || angle > flipOptions.flipThreshold) ? flipOptions.flipTo : ogAngle;

        Quaternion newAngle = (flipOptions.flipAxis == FlipOptions.FlipAxis.X_AXIS) ? Quaternion.Euler(flipAngle, transform.rotation.y, transform.rotation.z)
                         : (flipOptions.flipAxis == FlipOptions.FlipAxis.Y_AXIS) ? Quaternion.Euler(transform.rotation.x, flipAngle, transform.rotation.z)
                         :  Quaternion.Euler(transform.rotation.x, transform.rotation.y, flipAngle);

        foreach (GameObject obj in flipOptions.partsToFlip)
            Flip(obj, newAngle);
    }

    public void Flip(GameObject obj, Quaternion angle)
    {
        obj.transform.rotation = angle;
    }
}
