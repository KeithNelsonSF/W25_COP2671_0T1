using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    public UnityEvent OnMenuEnable;
    public UnityEvent OnMenuDisable;

    private void Start()
    {
        OnMenuEnable.Invoke();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && TimeKeeper.Instance.TimerStarted)
        {
            gameObject.SetActive(false);
            OnMenuDisable.Invoke();
        }
    }
}
