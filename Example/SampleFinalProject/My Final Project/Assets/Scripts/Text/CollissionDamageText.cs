using TMPro;
using UnityEngine;

public class CollissionDamageText : MonoBehaviour
{
    [SerializeField] TMP_Text collissionDamageText;
    private float currentCollissionDamge = 0f;

    private void Start()
    {
        collissionDamageText = GetComponent<TMP_Text>();
    }
    public void UpdateText(float collissionAmount)
    {
        currentCollissionDamge += collissionAmount;
        collissionDamageText.text = $"Vehicle Damage: {currentCollissionDamge}";

        GameManager.Instance.totalCollissionDamage = currentCollissionDamge;
    }
}
