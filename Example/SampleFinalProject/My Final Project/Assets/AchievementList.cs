using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementList : MonoBehaviour
{
    [SerializeField] RectTransform achievementGui;
    [SerializeField] Sprite hasMetImage;

    private void Start()
    {
        foreach (var achievement in AchievementManager.Instance.AchievementList)
        {            
            var gui = Instantiate(achievementGui, transform);
            var image = gui.gameObject.GetComponentInChildren<Image>();
            if (achievement.hasAchievementMet)
            {
                var metImage = image.GetComponentInChildren<Image>();
                metImage.sprite = hasMetImage;                
            }
            var text = gui.gameObject.GetComponentInChildren<TMP_Text>();
            text.text = achievement.achievementText;
            Debug.Log(achievement.achievementText);
        }
    }


}
