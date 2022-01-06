using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackAbstract : MonoBehaviour
{
    public Enemy enemy;

    // Update is called once per frame

    public abstract void Attack();
}
