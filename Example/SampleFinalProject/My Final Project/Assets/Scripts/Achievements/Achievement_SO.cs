using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "Scriptable Objects/Achievement")]
public class Achievement_SO : ScriptableObject
{
    public bool hasAchievementMet;
    public string achievementText;
    public int numberOfPizzaDeliveriesToMake;
    public float deliveryTime;
    
    public float runningTime;
    private int numberOfPizzasDeliveries;

    public void Start()
    {
        numberOfPizzasDeliveries = 0;
        hasAchievementMet = false;
        runningTime = 0f;
        GameManager.Instance.OnPizzaDelivered.AddListener(UpdatePizzaDelivered);
    }
    public void Update()
    {
        runningTime += Time.deltaTime;
    }
    private void UpdatePizzaDelivered(int pizzas)
    {
        if (hasAchievementMet) return;


        numberOfPizzasDeliveries++;

        if (numberOfPizzasDeliveries < numberOfPizzaDeliveriesToMake) return;
        if (deliveryTime > 0 && deliveryTime < runningTime) return;
        
            AchievementManager.Instance.OnAchievementMet.Invoke(achievementText, name);
            hasAchievementMet = true;
        
    }
}
