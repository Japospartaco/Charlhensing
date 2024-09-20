using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharlesController : AEveryCharlesController
{

    public GameObject projectilePrefab;
    private GameObject attackProjectile;
  

    public override void Attack()
    {
        if(attackProjectile == null)
        {
            attackProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }

}
