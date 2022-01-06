using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsPlayer : TowardsPlayer
{
    private GameObject player;
    [SerializeField]
    private Transform startPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (isAggroed)
        {
            Move();
        }
        else
        {
            Reset();
        }
    }
    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.getMoveSpeed() * Time.deltaTime);
    }
    public override void Reset()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPosition.position, enemy.getMoveSpeed() * Time.deltaTime);
    }
}
