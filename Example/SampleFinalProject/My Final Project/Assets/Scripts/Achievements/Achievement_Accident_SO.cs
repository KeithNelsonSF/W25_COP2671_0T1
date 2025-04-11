using UnityEngine;

[CreateAssetMenu(fileName = "Achievement_Accident_SO", menuName = "Scriptable Objects/Achievement_Accident_SO")]
public class Achievement_Accident_SO : Achievement_SO
{
    public override void UpdatePizzaDelivered(int pizzas)
    {
        if (GameManager.Instance.insuranceThreat)
        {
            if (hasAchievementMet) return;

            AchievementManager.Instance.OnAchievementMet.Invoke(achievementText, name);
            hasAchievementMet = true;
        }
    }
}
