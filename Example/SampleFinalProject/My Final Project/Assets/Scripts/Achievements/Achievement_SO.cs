using UnityEngine;

[CreateAssetMenu(fileName = "Achievement", menuName = "Scriptable Objects/Achievement")]
public class Achievement_SO : ScriptableObject
{
    public bool hasAchievementMet;
    public string achievementText;
    public int numberOfPizzaDeliveriesComplete;
    public float deliveryTime;
    public float deliveryDirection = 0f;    
    public float minCarDamage;
    public float actualCarDamage;
    

    public float runningTime;
    protected float drivenDirection;
    protected int numberOfPizzasDeliveries;

    public void Start()
    {
        numberOfPizzasDeliveries = 0;
        hasAchievementMet = false;
        runningTime = 0f;
        GameManager.Instance.OnPizzaDelivered.AddListener(UpdatePizzaDelivered);
    }
    public void UpdateLoop(float direction)
    {
        runningTime += Time.deltaTime;
        drivenDirection = direction;
        actualCarDamage = GameManager.Instance.damage;        
    }
    public virtual void UpdatePizzaDelivered(int pizzas)
    {
        if (hasAchievementMet) return;

        numberOfPizzasDeliveries++;
        if (numberOfPizzasDeliveries < numberOfPizzaDeliveriesComplete) return;
        if (deliveryTime > 0 && deliveryTime < runningTime) return;
        if (minCarDamage > 0 && actualCarDamage < minCarDamage) return;        
        if (deliveryDirection != 0 && drivenDirection * deliveryDirection <= 0) return;
                
        AchievementManager.Instance.OnAchievementMet.Invoke(achievementText, name);
        hasAchievementMet = true;        
    }
}
