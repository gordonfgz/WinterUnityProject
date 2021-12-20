using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnStay : AbstractStayContact
{
    public int amount;

    protected override void EnterEffect()
    {
        base.damageController.Damage(amount, base.contactHealth);
    }
    protected override void StayEffect()
    {
        base.damageController.Damage(amount, base.contactHealth);
    }
    protected override void ExitEffect(){}
}
