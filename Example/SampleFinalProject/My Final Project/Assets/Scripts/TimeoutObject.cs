using System.Collections;
using UnityEngine;

public class TimerObject : MonoBehaviour
{
    [SerializeField] float interval;    

    void Start()
    {        
        StartCoroutine(TimeoutCoroutine());
    }

    private IEnumerator TimeoutCoroutine()
    {
        yield return new WaitForSeconds(interval);
        Destroy(gameObject);
    }
}
