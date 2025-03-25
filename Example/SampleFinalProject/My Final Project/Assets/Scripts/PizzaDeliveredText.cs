using TMPro;
using UnityEngine;

public class PizzaDeliveredText : MonoBehaviour
{
    [SerializeField] TMP_Text pizzaDeiveredeText;
    int currentPizzaCount = 0;

    public void UpdateText(int pizzasToAdd)
    {
        currentPizzaCount += pizzasToAdd;
        pizzaDeiveredeText.text = $"Pizzas Delivered - {currentPizzaCount:00}";
    }    
}
