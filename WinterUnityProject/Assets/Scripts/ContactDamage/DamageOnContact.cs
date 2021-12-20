using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : AbstractContact
{
    public int amount;
    protected override void ContactEffect(Collider2D col)
    {
        base.damageController.Damage(amount, col.GetComponent<TestHealth>());
    }

}
