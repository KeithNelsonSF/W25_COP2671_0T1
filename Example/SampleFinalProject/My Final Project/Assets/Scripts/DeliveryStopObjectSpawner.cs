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
        GameManager.Instance.StartPizzaDelivery.AddListener(SelectNextDeliveryStop);
    }
    private IEnumerator ActivateNextDeliveryStop()
    {
        yield return null;

        var rnd = Random.Range(0, 9999) % pooledObjects.Count;
        pooledObjects[rnd].gameObject.SetActive(true);
        ScoreManager.Instance.OnDeliveryStopChanged.Invoke($"Pizza Run to {pooledObjects[rnd].name.Replace(" Variant","")}");
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
    public static void ReturnToPool(DeliveryStop deliveryStop)
    {
        deliveryStop.gameObject.SetActive(false);
    }
}
