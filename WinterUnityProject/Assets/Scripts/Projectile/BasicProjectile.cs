using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : AbstractProjectile
{
   protected override void Movement()
    {
        //rb2D.AddForce(gameObject.transform.right * base.speed);
        rb2D.velocity = transform.right * base.speed;
    }
}
