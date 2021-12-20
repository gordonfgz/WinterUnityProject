using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceDamageOnContact : AbstractContact
{
    public int reduction;
    public float duration;

    protected override void ContactEffect(Collider2D col)
    {
        base.coroutine = damageController.ReduceDamage(reduction, col.GetComponent<TestHealth>(), duration);
        StartCoroutine(base.coroutine);
    }
}
