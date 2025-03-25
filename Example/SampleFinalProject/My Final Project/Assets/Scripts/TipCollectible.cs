using System.Collections;
using UnityEngine;

public class TipCollectible : MonoBehaviour
{
    [SerializeField] float tipCalculatationMultiplier = 5f;

    public int tipAmount;
    private int tipDecreaseAmount;
    Coroutine tipCoroutine;
    DeliveryStop waypoint;
    
    private int distance;

    private void Awake()
    {
        waypoint = gameObject.transform.parent.GetComponent<DeliveryStop>();
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
    public int CalculateTip()
    {
        tipAmount += 1 * (tipDecreaseAmount / distance);
        return tipAmount;
    }
}
