using TMPro;
using UnityEngine;

public class PizzaDeliveredText : MonoBehaviour
{
    [SerializeField] TMP_Text pizzaDeiveredeText;
    //int currentPizzaCount = 0;

    private void Start()
    {
        pizzaDeiveredeText = GetComponent<TMP_Text>();
        UpdateText(0);
    }

    public void UpdateText(int pizzasToAdd)
    {
        GameManager.Instance.totalPizzasDelivered += pizzasToAdd;
        pizzaDeiveredeText.text = $"Pizzas Delivered - {GameManager.Instance.totalPizzasDelivered}";
    }    
}
