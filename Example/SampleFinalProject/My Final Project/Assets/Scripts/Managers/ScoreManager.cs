using UnityEngine.Events;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public UnityEvent<int> OnPizzaScoreChanged;
    public UnityEvent<int> OnTipsScoreChanged;
    public UnityEvent<float> OnCollissionDamge;
    public UnityEvent<string> OnDeliveryStopChanged;

    public void UpdateAll()
    {
        OnCollissionDamge.Invoke(GameManager.Instance.totalCollissionDamage);
        OnDeliveryStopChanged.Invoke(GameManager.Instance.currentDeliveryStopName);
        OnPizzaScoreChanged.Invoke(GameManager.Instance.totalPizzasDelivered);
        OnTipsScoreChanged.Invoke(GameManager.Instance.totalTipsCollected);
    }
}
