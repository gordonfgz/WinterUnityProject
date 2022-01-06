using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroZone : MonoBehaviour
{
    public TowardsPlayer[] enemyArray;      // Enemy Array tied to Arrgo Zone

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {   
            foreach (TowardsPlayer enemy in enemyArray)
            {
                //Debug.Log("Colliding!");
                enemy.isAggroed = true;
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            foreach (TowardsPlayer enemy in enemyArray)
            {
                //Debug.Log("Colliding!");
                enemy.isAggroed = false;

            }

        }
    }
}

