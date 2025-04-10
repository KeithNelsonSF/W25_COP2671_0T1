using System.Collections;
using UnityEngine;

public class AccidentSpawner : MonoBehaviour
{
    [SerializeField] private Accident[] prefabs;

    private IEnumerator Start()
    {
        while (isActiveAndEnabled)
        {
            if (GetComponentInChildren<Accident>() == null)
            {
                var randomTime = Random.Range(10, 21);
                yield return new WaitForSeconds(randomTime);
                var prefab = prefabs[Random.Range(0, prefabs.Length)];                
                Instantiate(prefab.gameObject, transform);
            }
            yield return null;
        }
        yield return null;
    }
}
