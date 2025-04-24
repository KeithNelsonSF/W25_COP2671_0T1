using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public UnityEvent OnPause;
    public UnityEvent OnResume;

    private bool isPaused => Time.timeScale == 0f;

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                OnResume.Invoke();
                Time.timeScale = 1f;
            }
            else
            {
                OnPause.Invoke();
                Time.timeScale = 0f;
            }
        }
    }
    public void ResumeGame()
    {
        OnResume.Invoke();
    }
}
