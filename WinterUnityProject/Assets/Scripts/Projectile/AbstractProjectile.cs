using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour
{
    public float speed;
    public float aliveTime = 10f;

    protected abstract void Movement();
    protected Rigidbody2D rb2D;

    void Start()
    {
        Invoke("Destroy", aliveTime);
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        Movement();
    }


    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
