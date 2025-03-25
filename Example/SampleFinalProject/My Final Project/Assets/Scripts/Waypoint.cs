using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float delay = 1.0f;
    [SerializeField] float height;
    MeshRenderer meshRenderer;

    public int pizzasToDeliver = 1;

    private void Awake()
    {        
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
    private void OnEnable()
    {
        meshRenderer.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {
            GameManager.Instance.OnDeliveryStart.Invoke(delay);
            gameObject.SetActive(false);
        }
    }
}
