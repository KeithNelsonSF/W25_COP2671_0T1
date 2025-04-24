using UnityEngine;

public class AchievementMenu : MonoBehaviour
{   
    public AchievementManager_SO achievements;
    public RectTransform achievementsPanel;    
    public Achievement achievementGui;
    public Sprite achievementMetIcon;
    public Sprite achievementNotMetIcon;


    private Color achievementMetColor = Color.green;
    private Color achievementNotMetColor = Color.white;

    private void OnEnable()
    {        
        foreach (var achievement in achievements.AchievementList)
        {
            Achievement achievement_instance = null;
            var go = GameObject.Find(achievement.name);
            if (go != null)
            {
                achievement_instance = go.GetComponent<Achievement>();
            }

            if (achievement_instance == null)
            {
                if (achievement.hasAchievementMet)
                {
                    achievement_instance = Instantiate(achievementGui, achievementsPanel.transform);
                }
                else
                {
                    achievement_instance = Instantiate(achievementGui, achievementsPanel.transform);
                }
            }
            achievement_instance.name = achievement.name;

            if (achievement.hasAchievementMet)
            {
                achievement_instance.achievement_image.sprite = achievementMetIcon;
                achievement_instance.achievement_image.color = achievementMetColor;
            }
            else
            {
                achievement_instance.achievement_image.sprite = achievementNotMetIcon;
                achievement_instance.achievement_image.color = achievementNotMetColor;
            }

            achievement_instance.achievement_text.text = achievement.achievementText;
        }
    }
}
