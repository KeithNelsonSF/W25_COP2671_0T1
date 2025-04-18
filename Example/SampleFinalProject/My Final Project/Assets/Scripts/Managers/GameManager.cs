using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    static string Horizontal = nameof(Horizontal);
    static string Vertical = nameof(Vertical);

    public UnityEvent OnGameStart;
    public UnityEvent OnGameLoad;
    public UnityEvent OnGameEnd;
    public UnityEvent<int> OnPizzaDelivered;
    public UnityEvent<int> StartPizzaDelivery;
    public UnityEvent<float> OnDeliveryStart;

    public SaveResults saveResults;

    public Vector2 driveDirections => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

    [SerializeField] CarController carPrefab;
    private CarController pizzaDeliveryVehicle;
    public Waypoint carSpawnPoint;
    public int lightPolesInScene;
    public int lightPolesTouched;

    public float damage = 0;
    public float damageMultiplier = 50f;

    public float carSpeed = .2f;

    public int pizzasToDeliver = 0;
    public int totalTipsCollected = 0;
    public int totalPizzasDelivered = 0;
    public float totalCollissionDamage = 0f;
    public string currentDeliveryStopName = "";
    public bool insuranceThreat;

    public void ResetTotals()
    {
        totalCollissionDamage = 0;
        totalTipsCollected = 0;
        totalPizzasDelivered = 0;
        ScoreManager.Instance.UpdateAll();
    }


    public override void InitializeAfterAwake()
    {
        OnGameLoad.Invoke();
    }
    private void Start()
    {
        MenuManager.Instance.OnGameStart.AddListener(() => GameStart());
        MenuManager.Instance.OnGameFinished.AddListener(() => GameEnd());
        MenuManager.Instance.OnGameAchievements.AddListener(() => GameAchievements());
        MenuManager.Instance.OnGameResume.AddListener(() => GameResume());
        MenuManager.Instance.OnGamePause.AddListener(() => GamePause());
        MenuManager.Instance.OnGameOver.AddListener(() => GameOver());

        OnDeliveryStart.AddListener(StartDelivery);
        OnPizzaDelivered.AddListener(PizzasDelivered);
    }
    private void GameEnd()
    {
        TimeKeeper.Instance.TimerQuit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    private void GameStart()
    {
        SpawnPizzaTruck();
        OnGameStart.Invoke();
    }
    private void GameOver() { }
    private void GamePause() { TimeKeeper.Instance.TimerPause(); }
    private void GameResume() { TimeKeeper.Instance.TimerResume(); }
    private void GameAchievements() { }
    private void StartDelivery(float delay)
    {
        pizzasToDeliver = Random.Range(1, 10);
        StartCoroutine(StartDeliveryWithDelay(delay));
    }
    private void PizzasDelivered(int pizzas)
    {
        carSpawnPoint.gameObject.SetActive(true);
        ScoreManager.Instance.OnDeliveryStopChanged.Invoke("Return for Dispatch!");
    }
    private IEnumerator StartDeliveryWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartPizzaDelivery.Invoke(pizzasToDeliver);
    }
    public void ResetPizzaTruck()
    {
        pizzaDeliveryVehicle.transform.position = carSpawnPoint.transform.position;
        pizzaDeliveryVehicle.transform.rotation = carSpawnPoint.transform.rotation;
    }
    public void SpawnPizzaTruck()
    {
        pizzaDeliveryVehicle = Instantiate(carPrefab, carSpawnPoint.transform.position, carSpawnPoint.transform.rotation);
    }

}
