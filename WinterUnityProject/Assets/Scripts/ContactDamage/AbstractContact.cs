using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractContact : MonoBehaviour
{
    public string[] tags = { "Player" };
    public bool destroyOnContact = false;

    protected DamageController damageController;
    protected IEnumerator coroutine;
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
                ContactEffect(other);

                if (destroyOnContact)
                    Destroy(this.gameObject);
            }
        }
    }

    // Effect on contact with gameObject
    protected abstract void ContactEffect(Collider2D col);

}
