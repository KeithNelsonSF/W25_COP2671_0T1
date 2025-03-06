using UnityEngine;

public class TipCollectible : MonoBehaviour
{
    [SerializeField] int tipAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {
            Debug.Log("car hit us");
        }
    }
}
