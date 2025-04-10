using UnityEngine;

[CreateAssetMenu(fileName = "Achievement_LightPole_SO", menuName = "Scriptable Objects/Achievement_LightPole_SO")]
public class Achievement_LightPole_SO : Achievement_SO
{
    public override void UpdatePizzaDelivered(int pizzas)
    {
        if (hasAchievementMet) return;

        if (GameManager.Instance.lightPolesInScene == GameManager.Instance.lightPolesTouched)
        {
            AchievementManager.Instance.OnAchievementMet.Invoke(achievementText, name);
            hasAchievementMet = true;
        }        
    }
}
