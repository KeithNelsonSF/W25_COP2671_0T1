using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "Scriptable Objects/Achievement")]
public class Achievement_SO : ScriptableObject
{
    public bool hasAchievementMet;
    public string achievementText;
    public int numberOfPizzaDeliveriesToMake;
    public float deliveryTime;
    public float minDamage;
    public float carDamage;


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
        carDamage = GameManager.Instance.damage;
    }
    private void UpdatePizzaDelivered(int pizzas)
    {
        if (hasAchievementMet) return;

        numberOfPizzasDeliveries++;
        if (numberOfPizzasDeliveries < numberOfPizzaDeliveriesToMake) return;
        if (deliveryTime > 0 && deliveryTime < runningTime) return;
        if (minDamage > 0 && carDamage < minDamage) return;
                
        AchievementManager.Instance.OnAchievementMet.Invoke(achievementText, name);
        hasAchievementMet = true;        
    }
}
