using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOnContact : AbstractContact
{
    public int amount;
    public float duration;

    protected override void ContactEffect(Collider2D col)
    {
        StartCoroutine(base.damageController.Slow(amount, col.GetComponent<TestHealth>(), duration));
    }
}
