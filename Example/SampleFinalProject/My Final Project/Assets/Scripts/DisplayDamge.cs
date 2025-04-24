using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 100;
    }
    public void UdateSlider(float damage)
    {
        GameManager.Instance.damage += damage * GameManager.Instance.damageMultiplier;
        slider.value -= damage * GameManager.Instance.damageMultiplier;

    }
    public void ResetSlider()
    {
        GameManager.Instance.damage = 0;
        slider.value = 100;
    }
}
