using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTurret : MonoBehaviour
{
    public float attackRate = 5.0f;
    public float aggroDistance = 15.0f;
    protected bool aggroed = false;
    protected GameObject player;

    // Start is called before the first frame update
    protected void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    protected void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < aggroDistance)
        {
            if (aggroed)
                return;

            aggroed = true;
            InvokeRepeating("Aggro", attackRate, attackRate);
        }
        else
        {
            CancelInvoke();
            aggroed = false;
            Idle();
        }
    }

    protected abstract void Idle();
    protected abstract void Aggro();
}
