using TMPro;
using UnityEngine;

public class TipsCollectedText : MonoBehaviour
{
    [SerializeField] TMP_Text tipsCollectedText;
    int currentTipAmount = 0;

    public void UpdateText(int tipAmountToAdd)
    {
        currentTipAmount += tipAmountToAdd;
        tipsCollectedText.text = $"Tips Collected - {currentTipAmount:$0.00}";
    }    
}
