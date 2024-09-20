using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class enemyPool : IPool
{
    private IPooledObject _charliePrefab;
    private IPooledObject _bigCharliePrefab;
    private IPooledObject _boneCharliePrefab;
    public EventHandler<int> EnemyDead;

    private List<IPooledObject> _charlies;

    int listSize;

    private int _activeCharlies;

    public enemyPool(IPooledObject charliePrefab, IPooledObject bigCharliePrefab, IPooledObject boneCharliePrefab, int numberEnemies)
    {
        _charliePrefab = charliePrefab ;
        _bigCharliePrefab = bigCharliePrefab;
        _boneCharliePrefab = boneCharliePrefab;

        listSize = numberEnemies;

        _charlies = new List<IPooledObject>(listSize);

        _activeCharlies = 0;

        for (int i = 0; i < listSize; i++)
        {
            if(i%3 == 0)
            {

                _charlies.Add(CreateCharlie(_charliePrefab));
            }
            if(i%3 == 1)
            {
                _charlies.Add(CreateCharlie(_bigCharliePrefab));
            }
            if(i%3 == 2)
            {
                _charlies.Add(CreateCharlie(_boneCharliePrefab));
            }
        }

    }

    private IPooledObject CreateCharlie(IPooledObject _charliePrefab)
    {

        IPooledObject newObj = _charliePrefab.Clone();
        return newObj;
    }

    public IPooledObject Get()
    {
        for (int i = 0; i < _charlies.Count; i++)
        {
            if (!_charlies[i].Active)
            {
                _charlies[i].Active = true;
                _activeCharlies += 1;
                return _charlies[i];
            }
        }
        return null;
    }

    public void Release(IPooledObject obj)
    {
        obj.Active = false;
        _activeCharlies -= 1;
        obj.Reset();
        EnemyDead?.Invoke(this, 0);

    }

    public int getCharliesCount()
    {
        return _charlies.Count;
    }

    public int GetActiveCharlies()
    {
        return _activeCharlies;
    }


}
