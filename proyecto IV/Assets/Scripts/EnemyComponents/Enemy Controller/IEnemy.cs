using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{

    
    public void MoveTowardsPlayer(Vector3 playerPos);
    public void Attack();

    public void SetState(IState newState);
    public IState GetState();

    public FlyWeightEnemy getEnemyType();
    public GameObject getPlayer();
    public GameObject GetGameObject();
}
