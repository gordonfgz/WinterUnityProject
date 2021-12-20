using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonOnContact : AbstractContact
{
    public int ticks;
    public int poisonDamage;
    public int delay;
    protected override void ContactEffect(Collider2D col)
    {
        base.coroutine = damageController.Poison(ticks, poisonDamage, delay, col.GetComponent<TestHealth>());
        StartCoroutine(base.coroutine);
    }
}
