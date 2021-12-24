using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : AbstractShoot
{
    [Tooltip("Keep number of bullets odd, if even is chosen, it is incremented")]
    public int numberOfBullets = 3;

    [Range(0, 180)]
    public float angleBetweenBullets = 15.0f;

    private float offset = 0;
    public void Start()
    {
        if(numberOfBullets % 2 == 0)
            numberOfBullets += 1;
    }

    public override IEnumerator Shoot()
    {
        base.Shooting();
        offset = 0;

        for (int i = 0; i < numberOfBullets; i++)
        {
            Vector3 appiedAngle = new Vector3(base.shoot.firePoint.localEulerAngles.x, base.shoot.firePoint.localEulerAngles.y, base.shoot.firePoint.localEulerAngles.z + offset);
            Instantiate(base.shoot.projectile, base.shoot.firePoint.position, Quaternion.Euler(appiedAngle));

            if (i % 2 == 1)
            {
                offset = -offset;
            }
            else
            {
                offset = offset;
                offset += angleBetweenBullets;
            }
        }
        yield return new WaitForSeconds(base.shoot.delayBetweenShots);
        base.NotShooting();
    }
}
