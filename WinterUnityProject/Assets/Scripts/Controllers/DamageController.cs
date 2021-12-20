using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    // Reduce health
    public void Damage(int amount, TestHealth thp /*, Health hp*/ )
    {
        Debug.Log("Health reduced");
        thp.hp -= amount;
        Debug.Log("Current Health: " + thp.hp);
    }
    // Assumption is made that status is tied to health script
    // Methods should be ran as a coroutine
    // Look at contact scripts for examples

    // Reduce speed
    public IEnumerator Slow (int slowAmt, TestHealth thp, float duration /*, Movement move*/ )
    {
        if (thp.slowed)
        {
            Debug.Log("currently slowed");
            yield break;
        }
        thp.slowed = true;
        Debug.Log("Speed slowed");
        // store original movespeed
        // Reduce target move speed
        yield return new WaitForSeconds(duration);
        // Revert back to original movespeed
        thp.slowed = false;
    }

    // Reduce Damage
    public IEnumerator ReduceDamage(int reduceAmt, TestHealth thp, float duration/*, Movement move*/ )
    {
        if (thp.damagedReduced)
        {
            Debug.Log("currently reduced");
            yield break;
        }
        thp.damagedReduced = true;
        Debug.Log("Damage Reduced");
        // store original attack
        // Reduce target attack
        yield return new WaitForSeconds(duration);
        // Revert back to original attack
        thp.damagedReduced = false;
    }

    // Posion Target
    public IEnumerator Poison(int ticks, int amt, float delay, TestHealth thp)
    {
        // If target is currently poisoned, break outta of new coroutine
        if (thp.poisoned == true)
        {
            Debug.Log("Currently Poisoned");
            yield break;
        }
        Debug.Log("Poisoned");
        thp.poisoned = true;

        for (int i = 0; i < ticks; i++)
        {
            yield return new WaitForSeconds(delay);
            Damage(amt, thp);
        }
        thp.poisoned = false ;
    }
}
