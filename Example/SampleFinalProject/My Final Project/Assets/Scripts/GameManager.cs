using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dummyCar;
    [SerializeField] CarController carPrefab;
    [SerializeField] Transform carSpawnPoint;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(carPrefab, carSpawnPoint.position, carSpawnPoint.rotation);
            var waypoint = DeliveryStopObjectSpawner.Instance.GetPooledObject();
            waypoint.gameObject.SetActive(true);
            dummyCar.SetActive(false);
        }
    }
}
