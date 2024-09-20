using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDuFogoHitManager : MonoBehaviour
{
    public float dmg = 1;
    private void OnTriggerStay2D(Collider2D col)
    {
        IEnemy enemy = col.gameObject.GetComponent<IEnemy>();

        if(enemy != null)
        {
            enemy.GetGameObject().GetComponent<EnemyHPController>().receiveDmg(dmg * Time.deltaTime);
        }
    }
   
}
