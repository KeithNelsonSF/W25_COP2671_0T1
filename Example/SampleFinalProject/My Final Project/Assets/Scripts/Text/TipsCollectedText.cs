using TMPro;
using UnityEngine;

public class TipsCollectedText : MonoBehaviour
{
    [SerializeField] TMP_Text tipsCollectedText;
    private void Start()
    {
        tipsCollectedText = GetComponent<TMP_Text>();
        UpdateText(0);
    }

    public void UpdateText(int tipAmountToAdd)
    {
        GameManager.Instance.totalTipsCollected += tipAmountToAdd;
        tipsCollectedText.text = $"Tips Collected - {GameManager.Instance.totalTipsCollected:$0.00}";
    }    
}
