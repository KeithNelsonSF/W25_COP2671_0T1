using System.Collections.Generic;
using UnityEngine;

public class DeliveryStopObjectSpawner : ObjectPool<Waypoint>
{
    [SerializeField] List<Waypoint> waypoints;

    public override void InitializeAfterAwake()
    {
        PoolObjects();
    }

    private void PoolObjects()
    {
        if (waypoints.Count == 0)
            return;

        _amount = waypoints.Count;
        _pooledObjects = new List<Waypoint>();

        GameObject newObject;
        for (int i = 0; i != _amount; ++i)
        {   
            var objToSpawn = waypoints[i];
            if (objToSpawn == null)
                objToSpawn = _prefab;

            newObject = Instantiate(objToSpawn.gameObject, transform);
            newObject.SetActive(false);
            newObject.name = objToSpawn.gameObject.name;

            _pooledObjects.Add(newObject.GetComponent<Waypoint>());
        }
        _isReady = true;
    }
}
