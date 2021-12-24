using System;
using UnityEngine;

[System.Serializable]
public class Shoot 
{
    public GameObject projectile;
    public Transform firePoint;
    public float delayBetweenShots = 2.0f;
}

