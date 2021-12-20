using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : AbstractShooter
{
    protected override void Shoot()
    {
        Instantiate(base.projectile, firePoint.position, firePoint.rotation);
    }
}
