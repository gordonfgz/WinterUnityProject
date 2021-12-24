using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : AbstractShoot
{
    public override IEnumerator Shoot()
    {
        base.Shooting();
        Instantiate(base.shoot.projectile, base.shoot.firePoint.position, base.shoot.firePoint.rotation);
        yield return new WaitForSeconds(base.shoot.delayBetweenShots);
        base.NotShooting();
    }
}
