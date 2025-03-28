using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 100;
    }
    public void UdateSlider(float damage)
    {
        slider.value -= damage * GameManager.Instance.damageMultiplier;

        if (slider.value <= 0)
        {
            GameManager.Instance.OnGameEnd.Invoke();
        }
    }
}
