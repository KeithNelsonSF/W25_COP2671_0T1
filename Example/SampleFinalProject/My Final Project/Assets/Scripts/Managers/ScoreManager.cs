using UnityEngine.Events;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public UnityEvent<int> OnPizzaScoreChanged;
    public UnityEvent<int> OnTipsScoreChanged;
    public UnityEvent<float> OnCollissionDamge;
    public UnityEvent<string> OnDeliveryStopChanged;
}
