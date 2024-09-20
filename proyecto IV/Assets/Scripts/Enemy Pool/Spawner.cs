using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    public GameObject charliePrefab;
    public GameObject bigCharliePrefab;
    public GameObject boneCharliePrefab;
    public int numberEnemies;
    public float enemiesPerSpawn;
    public float spreadArea;
    public int tasaDeSpawn;

    private float clock = 0;
    public enemyPool _enemyPool;

    private GameObject player;

    private void Awake()
    {
        
        player = GameObject.FindWithTag("Player");

        IPooledObject charlieComp = charliePrefab.GetComponent<IPooledObject>();
        IPooledObject bigCharlieComp = bigCharliePrefab.GetComponent<IPooledObject>();
        IPooledObject boneCharlieComp = boneCharliePrefab.GetComponent<IPooledObject>();

        _enemyPool = new enemyPool((IPooledObject)charlieComp, (IPooledObject)bigCharlieComp, (IPooledObject)boneCharlieComp, numberEnemies);
        
    }

    void Update()
    {

        clock += Time.deltaTime;
        if(clock >= tasaDeSpawn)
        {
            
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                
                AEveryCharlesController charlie = CreateCharlie();
            }
            clock = 0;
        }
    }


    private AEveryCharlesController CreateCharlie()
    {
        
        AEveryCharlesController charlie = (AEveryCharlesController)_enemyPool.Get();

        if (charlie)
        {
            charlie.pool = _enemyPool;
            float randAxis = Random.value;
            float x = 0, y = 0;
            if(randAxis>=0 && randAxis <= 0.25)
            {
                x = player.transform.position.x + spreadArea / 2;
                y = Random.value * spreadArea - spreadArea / 2;
            }
            else if(randAxis <= 0.5)
            {
                x = player.transform.position.x - spreadArea / 2;
                y = Random.value * spreadArea - spreadArea / 2;
            }
            else if(randAxis <= 0.75)
            {
                y = player.transform.position.x + spreadArea / 2;
                x = Random.value * spreadArea - spreadArea / 2;
            }
            else if(randAxis <= 1)
            {
                y = player.transform.position.x - spreadArea / 2;
                x = Random.value * spreadArea - spreadArea / 2;
            }
           
            charlie.transform.position = new Vector3(x, y, charlie.transform.position.z);

        }

        return charlie;
    }

}
