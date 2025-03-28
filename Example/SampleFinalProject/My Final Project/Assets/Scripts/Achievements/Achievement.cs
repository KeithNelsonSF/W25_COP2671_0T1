using UnityEngine;
using UnityEngine.Events;

public class Achievement : MonoBehaviour
{
    Canvas canvas;
    AudioSource audioSource;

    UnityEvent OnAchievementMet;

    [SerializeField] int numberOfPizzaDeliveriesToMeet;
    [SerializeField] float deliveryTime;
    [SerializeField] float runningTime;

    bool AchievementOneMet = false;
    bool AchievementTwoMet = false;

    int pizzaDeliveries;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    public bool AcheivementMet => AchievementOneMet && AchievementTwoMet;

    private void Start()
    {
        GameManager.Instance.OnPizzaDelivered.AddListener(UpdatePizzaCount);
    }
    private void UpdatePizzaCount(int pizzas)
    {
        pizzaDeliveries++;

        AchievementOneMet = pizzaDeliveries >= numberOfPizzaDeliveriesToMeet;
        AchievementTwoMet = runningTime <= deliveryTime;

        if (AcheivementMet)
        {
            canvas.enabled = true;
            audioSource.Play();

            Destroy(this.gameObject, audioSource.clip.length + 0.5f);
        }

    }
    private void Update()
    {
        runningTime += Time.deltaTime;
    }
}
