using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStayContact : MonoBehaviour
{
    public string[] tags = { "Player" };
    public float delay = 3.0f;

    protected DamageController damageController;
    protected IEnumerator coroutine;
    protected float counter = 0.0f;
    protected TestHealth contactHealth;

    void Start()
    {
        damageController = GameObject.Find("DamageController").GetComponent<DamageController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            if (other.tag == tags[i])
            {
                counter = 0;
                contactHealth = other.GetComponent<TestHealth>();
                EnterEffect();
                InvokeRepeating("StayEffect", delay, delay);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            if (other.tag == tags[i])
            {
                contactHealth = null;
                ExitEffect();
                CancelInvoke();
            }
        }
    }

    protected abstract void EnterEffect();
    protected abstract void StayEffect();
    protected abstract void ExitEffect();
}
