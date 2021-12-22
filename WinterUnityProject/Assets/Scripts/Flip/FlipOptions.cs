using System;
using UnityEngine;

[Serializable]
public class FlipOptions
{
    public enum FlipAxis
    {
        X_AXIS, Y_AXIS, Z_AXIS
    };

    public FlipAxis flipAxis = FlipAxis.Y_AXIS;

    public float flipThreshold = 90;
    public float flipTo = 180;
    public GameObject[] partsToFlip;
}

