using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovementAbstract : MonoBehaviour
{
    public Enemy enemy;

    // Abstract Method for Enemy Movement
    public abstract void Move();

    public abstract void Reset();
}
