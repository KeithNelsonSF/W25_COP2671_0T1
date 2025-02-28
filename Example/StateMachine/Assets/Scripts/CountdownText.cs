using TMPro;
using UnityEngine;

public class CountdownText : MonoBehaviour
{
        [SerializeField] TMP_Text timerText;

        float timerValue;


        private void Start()
        {
            timerText = GetComponent<TMP_Text>();
            timerText.text = $"Countdown:";

            TimeKeeper.Instance.OnCountDownChange.AddListener(ChangeTime);

        }
        private void ChangeTime(float currentTime)
        {
        timerText.text = "Countdown: " + $"{currentTime:F2}";
        }
}
