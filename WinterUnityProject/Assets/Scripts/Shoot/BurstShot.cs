using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShot : AbstractShoot
{
    public int bulletsPerBurst = 3;

    [Range(0, 1)]
    public float delayBetweenBulletsInBurst = 1.0f;

    public override IEnumerator Shoot()
    {
        base.Shooting();
        for(int i = 0; i < bulletsPerBurst; i++)
        {
            Instantiate(base.shoot.projectile, base.shoot.firePoint.position, base.shoot.firePoint.rotation);
            yield return new WaitForSeconds(delayBetweenBulletsInBurst);
        }
        yield return new WaitForSeconds(base.shoot.delayBetweenShots);
        base.NotShooting();
    }
}
