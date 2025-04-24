using TMPro;
using UnityEngine;

public class CollissionDamageText : MonoBehaviour
{
    [SerializeField] TMP_Text collissionDamageText;

    private void Start()
    {
        collissionDamageText = GetComponent<TMP_Text>();
        UpdateText(0);
    }
    public void UpdateText(float collissionAmount)
    {
        GameManager.Instance.totalCollissionDamage += collissionAmount;
        collissionDamageText.text = $"Vehicle Damage: {GameManager.Instance.totalCollissionDamage}";
    }
}
