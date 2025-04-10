using System.Collections;
using UnityEngine;

public class Accident : MonoBehaviour
{   
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(25);
        Destroy(gameObject);
        yield return null;
    }
}
