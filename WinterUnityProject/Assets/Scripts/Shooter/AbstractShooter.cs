using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooter : MonoBehaviour
{
    public GameObject projectile;
    public float rate;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }
    protected abstract void Shoot();
}
