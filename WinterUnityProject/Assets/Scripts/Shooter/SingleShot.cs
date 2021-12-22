using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : AbstractShooter
{
    protected override IEnumerator Shoot()
    {
        base.Shooting();
        Instantiate(base.projectile, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(base.delayBetweenTracks);
        base.NotShooting();
    }
}
