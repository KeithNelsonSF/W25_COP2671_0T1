using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public UnityEvent OnGameStart;
    public UnityEvent<int> OnPizzaDelivered;
    public UnityEvent<int> StartPizzaDelivery;
    public UnityEvent<float> OnDeliveryStart;

        
    [SerializeField] CarController carPrefab;
    public Waypoint carSpawnPoint;
    public int pizzasToDeliver = 0;
    public int tipsCollected = 0;
    public int pizzasDelivered = 0;

    public string currentDeliveryStopName = "";

    private void Start()
    {
        OnDeliveryStart.AddListener(StartDelivery);
        OnPizzaDelivered.AddListener(PizzasDelivered);    
        

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
}
