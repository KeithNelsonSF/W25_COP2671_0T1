using UnityEngine.Events;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public UnityEvent<int> OnPizzaScoreChanged;
    public UnityEvent<int> OnTipsScoreChanged;
    public UnityEvent<string> OnDeliveryStopChanged;
}
