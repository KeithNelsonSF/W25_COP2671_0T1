using UnityEngine.Events;

public class MenuManager : SingletonMonoBehaviour<MenuManager>
{
    public UnityEvent OnGameOver;
    public UnityEvent OnGameStart;
    public UnityEvent OnGameFinished;
    public UnityEvent OnGameSettings;
    public UnityEvent OnGameAchievements;

    public void GameOver() { OnGameOver.Invoke(); }    
    public void GameStart() { OnGameStart.Invoke(); }    
    public void GameFinished() { OnGameFinished.Invoke(); }
    public void GameSettings() { OnGameSettings.Invoke(); }
    public void GameAchievements() { OnGameAchievements.Invoke(); }
}
