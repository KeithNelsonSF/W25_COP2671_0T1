using TMPro;
using UnityEngine;

public class DeliveryStopText : MonoBehaviour
{
    [SerializeField] TMP_Text deliveryStopText;
    private void Start()
    {
        deliveryStopText = GetComponent<TMP_Text>();
    }
    public void UpdateText(string location)
    {
        deliveryStopText.text = location;
    }
}
