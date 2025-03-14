using System.Collections;
using UnityEngine;

public class DeliveryStop : MonoBehaviour
{
    [SerializeField] float height;
    
    public int pizzasToDeliver = 1;
    public int distanceToPizzaShop = 0;
    public int tipAmount;


    ParticleSystem tipParticle;
    TipCollectible tipCollectible;
    MeshRenderer meshRenderer;    

    public void Activate()
    {
        meshRenderer.enabled = true;
    }
    public void Dectivate()
    {
        meshRenderer.enabled = false;
    }
    void Start()
    {
        tipCollectible = GetComponentInChildren<TipCollectible>();
        tipCollectible.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        if (tipCollectible != null)
        {
            tipCollectible.gameObject.SetActive(true);
        }

        tipParticle = GetComponentInChildren<ParticleSystem>();
        tipParticle.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        if (tipParticle != null)
        {
            tipParticle.gameObject.SetActive(true);
        }

        distanceToPizzaShop = CalculateDistanceToPizzaShop();
        //GameManager.Instance.OnDeliveryStart.AddListener((pizzas) => pizzasToDeliver = pizzas);
        //GameManager.Instance.OnPizzaDelivered.AddListener((pizzas) => gameObject.SetActive(false));
    }
    public int CalculateDistanceToPizzaShop()
    {
        return (int)Vector3.Distance(transform.position, GameManager.Instance.carSpawnPoint.transform.position) * 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {            
            GameManager.Instance.pizzasDelivered += pizzasToDeliver;
            if (tipAmount > 0)
            {
                GameManager.Instance.tipsCollected += tipAmount;
                StartCoroutine(tipTheDriver());
            }
            GameManager.Instance.OnPizzaDelivered.Invoke(pizzasToDeliver);
            gameObject.SetActive(false);            
        }
    }


    private IEnumerator tipTheDriver()
    {
        tipCollectible.gameObject.SetActive(false);
        tipParticle.Play();
        yield return new WaitForSeconds(tipParticle.main.duration);
    }
}
