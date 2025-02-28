using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public float speed = 8;
    public int highScore = 5;

    public override void InitializeAfterAwake()
    {

        //highScore = PlayerPrefs.GetInt(nameof(highScore));
        //speed = PlayerPrefs.GetFloat(nameof(speed));

        
    }
    private void Start()
    {        
        TimeKeeper.Instance.OnStop.AddListener(StopGame);
        TimeKeeper.Instance.OnCountdownEnd.AddListener(
            () => Debug.Log("Count Down Ended")); 
    }    
    public void StopGame() 
    {
        PlayerPrefs.SetInt(nameof(highScore), highScore);
        PlayerPrefs.SetFloat(nameof(speed), speed);
    }
}
