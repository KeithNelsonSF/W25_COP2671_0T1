using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public UnityEvent OnGameStart;
    public UnityEvent OnGameLoad;
    public UnityEvent OnGameEnd;
    public UnityEvent<int> OnPizzaDelivered;
    public UnityEvent<int> StartPizzaDelivery;
    public UnityEvent<float> OnDeliveryStart;

    public SaveResults saveResults;


    [SerializeField] CarController carPrefab;
    public Waypoint carSpawnPoint;
    public float damageMultiplier = 50f;

    public float carSpeed = .2f;

    public int pizzasToDeliver = 0;
    public int totalTipsCollected = 0;
    public int totalPizzasDelivered = 0;
    public float totalCollissionDamage = 0f;
    public string currentDeliveryStopName = "";

    public override void InitializeAfterAwake()
    {
        OnGameLoad.Invoke();
    }
    private void Start()
    {
        OnDeliveryStart.AddListener(StartDelivery);
        OnPizzaDelivered.AddListener(PizzasDelivered);
        OnGameEnd.AddListener(() => Debug.Log("Game Over"));


        // on timer start
        //  disable scene
        //  






        // tips collect
        //  sound ?
        // pizza delivered
        //  sound ?
        //  update score

        // accidents caused
        //  sound ?



        // -- game play --
        // random tip amount or calculated?   
        //      minimum, plus every 10 seconds an extra 1
        //      maximum based on # pizxa times (value), decrease based on deliver time.
        // random tip timeout calculated or fixed?
        //      distance * 2
        // what cause a game over condition?
        //  played for 10 minutes.
        // what cause a win condition?
        // goal - collect 10 dollars.

        // -- score board --
        // tip's collected - dolloar amount
        // deliveries made - 
        // accidents caused -- 
        // display countdown for what??
        //  rounds

        // -- backlog --
        // miles driven, start - finish / toal game
        // achievemant system
    }

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
    public void SpawnPizzaTruck()
    {
        Instantiate(carPrefab, carSpawnPoint.transform.position, carSpawnPoint.transform.rotation);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
