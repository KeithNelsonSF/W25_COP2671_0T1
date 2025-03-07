using System.Collections.Generic;
using UnityEngine;

public class DeliveryStopObjectSpawner : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints;

    [SerializeField] List<GameObject> pooledObjects = new List<GameObject>();

    private void Start()
    {
        PoolObjects();
        GameManager.Instance.OnDeliveryStart.AddListener(SelectNextDeliveryStop);
    }

    private void SelectNextDeliveryStop(int pizzas)
    {
        var rnd = Random.Range(0, pooledObjects.Count -1);
        pooledObjects[1].gameObject.SetActive(true);
    }
    private void PoolObjects()
    {
        if (waypoints.Count == 0)
            return;

        GameObject newObject;
        for (int i = 0; i != waypoints.Count; ++i)
        {   
            newObject = Instantiate(waypoints[i].gameObject, transform);
            newObject.SetActive(false);
            newObject.name = waypoints[i].gameObject.name;
            pooledObjects.Add(newObject);
        }
    }
}
