using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class will allow us to instantiate as many objects as we will need
/// while the scene is being setup so that we don't slow down the game by
/// calling instantiate during gameplay.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> : SingletonMonoBehaviour<ObjectPool<T>> where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    protected List<T> _pooledObjects;
    protected int _amount = 0;
    protected bool _isReady = false;
    /// <summary>
    /// This function will pre-create a specific number of objects in the pool.
    /// </summary>
    /// <param name="amount">number of objects to setup initially</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void PoolObjects(int amount = 0)
    {
        if (amount < 0)
            throw new System.ArgumentOutOfRangeException("Amount to pool must be non-negative.");

        _amount = amount;
        _pooledObjects = new List<T>(amount);

        GameObject newObject;
        for (int i = 0; i != amount; ++i)
        {
            newObject = Instantiate(_prefab.gameObject, transform);
            newObject.SetActive(false);
            newObject.name = _prefab.gameObject.name;

            _pooledObjects.Add(newObject.GetComponent<T>());
        }
        _isReady = true;
    }
    public void PoolObjects(int amount, List<T> objectsToSpawn)
    {
        if (amount < 0)
            throw new System.ArgumentOutOfRangeException("Amount to pool must be non-negative.");

        _amount = amount;
        _pooledObjects = new List<T>(amount);

        GameObject newObject;
        for (int i = 0; i != amount; ++i)
        {
            var index = Random.Range(0, objectsToSpawn.Count);
            var objToSpawn = objectsToSpawn[index];
            if (objToSpawn == null)
                objToSpawn = _prefab;

            newObject = Instantiate(objToSpawn.gameObject, transform);
            newObject.SetActive(false);
            newObject.name = objToSpawn.gameObject.name;

            _pooledObjects.Add(newObject.GetComponent<T>());
        }
        _isReady = true;
    }

    /// <summary>
    /// Retrieve the next available object from the pool
    /// </summary>
    /// <returns>next available object</returns>
    public T GetPooledObject()
    {
        if (_isReady == false)
            PoolObjects(1);

        for (int i = 0; i != _amount; ++i)
        {
            if (_pooledObjects[i].isActiveAndEnabled == false)
                return _pooledObjects[i];
        }

        return _pooledObjects[0];
    }
    /// <summary>
    /// Returns an object to the pool
    /// </summary>
    /// <param name="toBeReturned">object to return</param>
    public void ReturnObjectToPool(T toBeReturned)
    {
        if (toBeReturned == null) return;

        if (!_isReady)
        {
            PoolObjects();
            _pooledObjects.Add(toBeReturned);
        }

        toBeReturned.gameObject.SetActive(false);
    }
}