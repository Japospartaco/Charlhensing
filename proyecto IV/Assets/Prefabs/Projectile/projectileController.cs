using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class projectileController : MonoBehaviour, IProjectile
{
    public int speed = 6;
    private Vector3 origin;
    private Vector3 objective;
    private int dmg = 15;
    private float maxDistance = 12;

    private void Awake()
    {
        origin = transform.position;
        objective = GameObject.FindWithTag("Player").transform.position - origin;
        objective = new Vector3(objective.x * 1000000, objective.y * 1000000, objective.z);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, origin) <= maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, objective, speed * Time.deltaTime);
        }
        else Destroy(gameObject);  
    }

    public int getDmg()
    {
        return dmg;
    }
}
