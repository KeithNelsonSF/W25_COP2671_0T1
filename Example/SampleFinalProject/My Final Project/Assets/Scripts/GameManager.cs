using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public UnityEvent<int> OnPizzaDelivered;
    public UnityEvent<int> OnDeliveryStart;

    [SerializeField] GameObject dummyCar;
    [SerializeField] CarController carPrefab;
    public Transform carSpawnPoint;
    public int pizzasToDeliver = 0;

    private void Start()
    {
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

    private void CalculatePizzasToDeliver()
    {
        pizzasToDeliver = Random.Range(1, 10);
        OnDeliveryStart.Invoke(pizzasToDeliver);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(carPrefab, carSpawnPoint.position, carSpawnPoint.rotation);
            CalculatePizzasToDeliver();
            dummyCar.SetActive(false);
        }
    }
}
