using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float height;
    
    public int pizzasToDeliver = 1;
    public int distanceToPizzaShop = 0;
    public int tipAmount;


    TipCollectible tipCollectible;
    MeshRenderer meshRenderer;    

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        tipCollectible = GetComponentInChildren<TipCollectible>();
        if (tipCollectible != null)
        {
            tipCollectible.gameObject.SetActive(true);
        }

        distanceToPizzaShop = CalculateDistanceToPizzaShop();
        GameManager.Instance.OnDeliveryStart.AddListener((pizzas) => pizzasToDeliver = pizzas);
        GameManager.Instance.OnPizzaDelivered.AddListener((pizzas) => gameObject.SetActive(false));
    }
    public int CalculateDistanceToPizzaShop()
    {
        return (int)Vector3.Distance(transform.position, GameManager.Instance.carSpawnPoint.position) * 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {
            GameManager.Instance.OnPizzaDelivered.Invoke(pizzasToDeliver);
        }
    }
}
