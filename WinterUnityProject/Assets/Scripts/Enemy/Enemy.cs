using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float damage;

    public float getHealth()
    { 
        return health; 
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public float getDamage()
    {
        return damage;
    }
}
