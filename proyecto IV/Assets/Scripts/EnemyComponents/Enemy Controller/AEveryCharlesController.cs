using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEveryCharlesController : MonoBehaviour, IEnemy, IPooledObject
{
    public FlyWeightEnemy enemyType;
    protected GameObject Player;
    public IState actualState;
    public IPool pool;

    public bool Active
    {
        get
        {
            return gameObject.activeSelf;
        }
        set
        {
            gameObject.SetActive(value);
        }
    }

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        SetState(new ChasingState(this));
    }

    private void Update()
    {
        actualState.Update();
    }

    public void MoveTowardsPlayer(Vector3 playerPos)
    {
        //CAMBIO DE EJE SPRITE
        transform.position = Vector3.MoveTowards(transform.position, playerPos,
                    enemyType.Speed * Time.deltaTime);
    }

    public abstract void Attack();

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public IState GetState()
    {
        return actualState;
    }

    public void SetState(IState newState)
    {
        if (actualState != null)
        {
            actualState.Exit();
        }
        actualState = newState;
        actualState.Enter();
    }

    public GameObject getPlayer()
    {
        return Player;
    }

    public FlyWeightEnemy getEnemyType()
    {
        return enemyType;
    }

    public void Reset()
    {
        SetState(new ChasingState(this));
        transform.localPosition = Vector3.zero;
        GetComponent<EnemyHPController>().HP = enemyType.MaxHP;
    }

    public IPooledObject Clone()
    {
        GameObject newObject = Instantiate(gameObject);
        AEveryCharlesController clonedEnemy = newObject.GetComponent<AEveryCharlesController>();
        return clonedEnemy;
    }

}
