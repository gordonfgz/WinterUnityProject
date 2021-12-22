using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NotTowardsPlayer
{
    public Transform[] waypointList;
    private int index = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypointList[index].position, enemy.getMoveSpeed()*Time.deltaTime);

        if (transform.position == waypointList[index].transform.position) index++;
        if (index == waypointList.Length) index = 0;
    }
}
