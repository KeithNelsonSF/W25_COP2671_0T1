using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float height;
    MeshRenderer meshRenderer;

    public int pizzasToDeliver = 1;

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.transform.position = new Vector3(transform.position.x, height, transform.position.z);



        //GameManager.Instance.OnDeliveryStart.AddListener((pizzas) => pizzasToDeliver = pizzas);
        //GameManager.Instance.OnPizzaDelivered.AddListener((pizzas) => gameObject.SetActive(false));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {            
            gameObject.SetActive(false);
            GameManager.Instance.CalculatePizzasToDeliver();
        }
    }
}
