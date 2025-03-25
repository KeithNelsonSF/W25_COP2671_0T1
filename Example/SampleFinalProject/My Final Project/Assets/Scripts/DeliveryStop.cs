using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryStop : MonoBehaviour
{
    [SerializeField] float height;
    
    public int pizzasToDeliver = 1;

    ParticleSystem tipParticle;
    TipCollectible tipCollectible;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        tipCollectible = GetComponentInChildren<TipCollectible>();
        tipCollectible.transform.position = new Vector3(transform.position.x, height, transform.position.z);

        tipParticle = GetComponentInChildren<ParticleSystem>();
        tipParticle.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
    private void OnEnable()
    {
        if (tipCollectible != null)
        {
            tipCollectible.gameObject.SetActive(true);
        }
        if (tipParticle != null)
        {
            tipParticle.gameObject.SetActive(true);
        }
        pizzasToDeliver = Random.Range(1, 10);
    }
    public void Activate()
    {
        meshRenderer.enabled = true;
    }
    public void Dectivate()
    {
        meshRenderer.enabled = false;
    }    
    public int CalculateDistanceToPizzaShop()
    {
        return (int)Vector3.Distance(transform.position, GameManager.Instance.carSpawnPoint.transform.position) * 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {
            ScoreManager.Instance.OnPizzaScoreChanged.Invoke(pizzasToDeliver);
            var tipAmount = tipCollectible.CalculateTip();
            if (tipAmount > 0)
            {
                ScoreManager.Instance.OnTipsScoreChanged.Invoke(tipAmount);
                StartCoroutine(tipTheDriver());
            }
            GameManager.Instance.OnPizzaDelivered.Invoke(pizzasToDeliver);
            DeliveryStopObjectSpawner.ReturnToPool(this);
        }
    }
    private IEnumerator tipTheDriver()
    {
        tipCollectible.gameObject.SetActive(false);
        tipParticle.Play();
        yield return new WaitForSeconds(tipParticle.main.duration);
    }
}
