using TMPro;
using UnityEngine;

public class TipsCollectedText : MonoBehaviour
{
    [SerializeField] TMP_Text tipsCollectedText;
    int currentTipAmount = 0;

    private void Start()
    {
        tipsCollectedText = GetComponent<TMP_Text>();
    }

    public void UpdateText(int tipAmountToAdd)
    {
        currentTipAmount += tipAmountToAdd;
        tipsCollectedText.text = $"Tips Collected - {currentTipAmount:$0.00}";

        GameManager.Instance.totalTipsCollected = currentTipAmount;
    }    
}
