using System.Collections;
using TMPro;
using UnityEngine;

public class PizzaDeliveredText : MonoBehaviour
{

    [SerializeField] TMP_Text pizzaDEliveredeText;

    private void Start()
    {
        pizzaDEliveredeText = GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {
        StartCoroutine(WaitForSecond());
    }
    private IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(2);
        pizzaDEliveredeText.text = "Pizzas Delivered - " + GameManager.Instance.pizzasDelivered;
    }
}
