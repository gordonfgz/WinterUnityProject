using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShoot : MonoBehaviour
{
    public Shoot shoot;

    [HideInInspector]
    public bool shooting = false;

    public abstract IEnumerator Shoot();

    protected void Shooting()
    {
        shooting = true;
    }

    protected void NotShooting()
    {
        shooting = false;
    }
}
