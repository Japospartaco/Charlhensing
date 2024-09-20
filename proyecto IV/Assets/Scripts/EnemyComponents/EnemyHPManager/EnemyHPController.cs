using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHPController : MonoBehaviour
{
    public float HP;

    private void Awake()
    {
        HP = GetComponent<IEnemy>().getEnemyType().MaxHP;
    }

    public void receiveDmg(float dmg)
    {
        HP -= dmg;
        if(HP <= 0)
        {
            gameObject.GetComponent<AEveryCharlesController>().pool.Release(gameObject.GetComponent<AEveryCharlesController>());
        }
    }
}
