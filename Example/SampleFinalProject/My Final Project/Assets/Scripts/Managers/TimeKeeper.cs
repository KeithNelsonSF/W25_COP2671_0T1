using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeKeeper : SingletonMonoBehaviour<TimeKeeper>
{
    // timer level events
    public UnityEvent OnStart;
    public UnityEvent OnStop;
    public UnityEvent OnPause;
    public UnityEvent OnResume;
    public UnityEvent OnQuit;
    
    // time events
    public UnityEvent OnCountdownStart;
    public UnityEvent OnCountdownEnd;
    public UnityEvent<float> OnCountDownChange;
    public UnityEvent<float> OnChange;
    
    private Coroutine timeCoroutine;    

    [SerializeField] float countdownTime;
    float elaspedTime = 0f;
    float countdownElapsedTime = 0;
    public bool IsRunning
    {
        get { return Time.timeScale == 1f; }
    }
    public bool TimerStarted = false;

    private void Start()
    {
        Time.timeScale = 0f;
        countdownElapsedTime = countdownTime;        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            if (IsRunning)
            {
                TimerPause();
            }            
        }
    }

    private IEnumerator TimeCoroutine()
    {
        while(isActiveAndEnabled)
        {
            while(IsRunning)
            {
                if (countdownElapsedTime > 0)
                {
                    if (countdownElapsedTime == countdownTime)
                        OnCountdownStart.Invoke();

                    countdownElapsedTime -= Time.deltaTime;
                } 
                else
                {
                    countdownElapsedTime = 0;
                    OnCountdownEnd.Invoke();
                    TimerStop();
                }
                OnCountDownChange.Invoke(countdownElapsedTime);

                elaspedTime += Time.deltaTime;
                OnChange.Invoke(elaspedTime);
                yield return null;
            }
            yield return null;
        }
    }

    public void TimerStart() 
    {
        TimerStarted = true;
        Time.timeScale = 1f;        
        timeCoroutine = StartCoroutine(TimeCoroutine());
        OnStart.Invoke();
    }
    public void TimerStop()
    {
        TimerStarted = false;
        //Time.timeScale = 0f;
        //StopCoroutine(timeCoroutine);
        //OnStop.Invoke();
    }
    public void TimerPause()
    {
        OnPause.Invoke();
        Time.timeScale = 0f;
    }
    public void TimerResume()
    {
        Time.timeScale = 1f;
        OnResume.Invoke();
    }
    public void TimerQuit()
    {
        TimerStop();
        OnQuit.Invoke();
    }
}
