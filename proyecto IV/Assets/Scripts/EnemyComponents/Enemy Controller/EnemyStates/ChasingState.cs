using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : AEnemyState
{
    private Vector3 playerPos;
    private GameObject Player;
    private FlyWeightEnemy enemyType;


    public ChasingState(IEnemy enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        Player = enemy.getPlayer();
        playerPos = Player.transform.position;
        enemyType = enemy.getEnemyType();
    }
    public override void Exit()
    {
        
    }
    public override void Update()
    {
        playerPos = Player.transform.position;

        if (Vector3.Distance(playerPos, enemy.GetGameObject().transform.position) <= enemyType.Range)
        {
            enemy.SetState(new AttackState(enemy));
        }
        else
        {
            enemy.MoveTowardsPlayer(playerPos);
        }
    }

    public override void FixedUpdate()
    {
       
    }
}
