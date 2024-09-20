using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RemainingEnemies : MonoBehaviour
{
    public TMP_Text mText;
    public int remaining;

    private void EnemyDead(object sender, int nothings)
    {
        remaining--;
        mText.text = "Remaining enemies:  " + remaining;
    }

    private void Start()
    {
        mText.text = "Remaining enemies:  " + remaining;
        GameObject pool = GameObject.FindWithTag("GameManager");

        pool.GetComponent<Spawner>()._enemyPool.EnemyDead += EnemyDead;
    }



}