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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameManager.Instance.insuranceThreat = true;
        }
    }
}
