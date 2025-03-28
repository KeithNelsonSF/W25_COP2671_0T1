using System.Collections;
using UnityEngine;

public class TipCollectible : MonoBehaviour
{
    private float tipCalculatationMultiplier;
    private int tipBase = 0;
    private int tipAmount;
    private int tripDistance;
    private float tipDecreaseAmount;
    Coroutine tipCoroutine;
    DeliveryStop deliveryStop;

    private void Awake()
    {
        deliveryStop = gameObject.transform.parent.GetComponent<DeliveryStop>();        
        tripDistance = deliveryStop.CalculateDistanceToPizzaShop();
        tipDecreaseAmount = tripDistance;        
    }
    private void Start()
    {
        SetMultiplier(1f);
        tipCoroutine = StartCoroutine(DecreaseTimeAmountCo());
    }
    private IEnumerator DecreaseTimeAmountCo()
    {
        while (tipDecreaseAmount > 0f)
        {
            yield return null;
                //new WaitForSeconds(1);
            tipDecreaseAmount -= Time.deltaTime;
        }
        if (tipDecreaseAmount <= 0f)
        {
            tipDecreaseAmount = 0f;
            StopCoroutine(tipCoroutine);
        }
        Debug.Log(tipDecreaseAmount);
        yield return null;
    }

    public float SetMultiplier(float multiplier)
    {
        tipCalculatationMultiplier = multiplier;
        tipBase = Mathf.FloorToInt(GameManager.Instance.pizzasToDeliver * tipCalculatationMultiplier);
        return tipCalculatationMultiplier;
    }
    public int CalculateTip()
    {
        tipAmount = tipBase - (1 - Mathf.FloorToInt(tipDecreaseAmount / tripDistance));
        return tipAmount;
    }
}
