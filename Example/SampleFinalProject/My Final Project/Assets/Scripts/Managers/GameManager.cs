using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public UnityEvent<int> OnPizzaDelivered;
    public UnityEvent<int> OnDeliveryStart;
        
    [SerializeField] CarController carPrefab;
    public Waypoint carSpawnPoint;
    public int pizzasToDeliver = 0;
    public int tipsCollected = 0;
    public int pizzasDelivered = 0;

    public string currentDeliveryStopName = "";

    private void Start()
    {
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

    public void CalculatePizzasToDeliver()
    {
        pizzasToDeliver = Random.Range(1, 10);
        StartCoroutine(WaitForSecond());
    }

    private void PizzasDelivered(int pizzas)
    {
        
    }

    private IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(1);
        OnDeliveryStart.Invoke(pizzasToDeliver);
    }


    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {   
    //        SpawnPizzaTruck();
    //    }
    //}

    public void SpawnPizzaTruck()
    {
        Instantiate(carPrefab, carSpawnPoint.transform.position, carSpawnPoint.transform.rotation);        
    }
}
