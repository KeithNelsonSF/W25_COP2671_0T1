using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    float timerValue;


    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
        timerText.text = $"Timer:";

        TimeKeeper.Instance.OnChange.AddListener(ChangeTime);

    }
    private void ChangeTime(float currentTime)
    {
        timerText.text = "Timer: " + $"{currentTime:F2}";
    }
}
