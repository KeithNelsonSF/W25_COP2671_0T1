using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryStopObjectSpawner : MonoBehaviour
{
    [SerializeField] List<DeliveryStop> waypoints;
    [SerializeField] List<GameObject> pooledObjects = new List<GameObject>();

    private void Start()
    {
        PoolObjects();
        GameManager.Instance.OnDeliveryStart.AddListener(SelectNextDeliveryStop);
    }
    private IEnumerator ActivateNextDeliveryStop()
    {
        yield return new WaitForSeconds(1); 

        var rnd = Random.Range(0, pooledObjects.Count - 1);
        pooledObjects[rnd].gameObject.SetActive(true);
        GameManager.Instance.currentDeliveryStopName = pooledObjects[rnd].name;
    }
    private void SelectNextDeliveryStop(int pizzas)
    {
        StartCoroutine(ActivateNextDeliveryStop());        
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
