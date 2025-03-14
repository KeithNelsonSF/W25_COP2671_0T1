using System.Collections;
using TMPro;
using UnityEngine;

public class DeliveryStopText : MonoBehaviour
{
    [SerializeField] TMP_Text deliveryStopText;

    private void Start()
    {
        deliveryStopText = GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {   
        StartCoroutine(WaitForSecond());
    }
    private IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(2);
        deliveryStopText.text = "Deliver to " + GameManager.Instance.currentDeliveryStopName;
    }
}
