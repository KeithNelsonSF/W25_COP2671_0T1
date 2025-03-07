using System.Collections;
using UnityEngine;

public class TipCollectible : MonoBehaviour
{
    [SerializeField] float tipCalculatationMultiplier = 5f;

    private int tipDecreaseAmount;
    Coroutine tipCoroutine;
    Waypoint waypoint;

    private int tipAmount;
    private int distance;
    private void Start()
    {
         waypoint = gameObject.transform.parent.GetComponent<Waypoint>();       

        tipAmount = Mathf.FloorToInt(waypoint.pizzasToDeliver * tipCalculatationMultiplier);

        distance = tipDecreaseAmount = waypoint.CalculateDistanceToPizzaShop();
        tipCoroutine = StartCoroutine(DecreaseTimeAmountCo());
    }
    private IEnumerator DecreaseTimeAmountCo()
    {
        while (tipDecreaseAmount > 0)
        {
            yield return new WaitForSeconds(1);
            tipDecreaseAmount -= 1;            
        }
        if (tipDecreaseAmount <= 0)
        {
            tipDecreaseAmount = 0;
            StopCoroutine(tipCoroutine);
        }
        Debug.Log(tipDecreaseAmount);
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CarController carController))
        {
            StopCoroutine(tipCoroutine);

            tipAmount += 1 * (tipDecreaseAmount/distance);
            waypoint.tipAmount = tipAmount;
            gameObject.SetActive(false);
        }
    }
}
