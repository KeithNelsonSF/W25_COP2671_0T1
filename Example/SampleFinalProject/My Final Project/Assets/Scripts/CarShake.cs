using UnityEngine;

public class CarShake : MonoBehaviour
{
    // vibrate car by moving x and z axis randomly
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        var shake = new Vector3(Random.Range(0.01f, 0.03f), 0, Random.Range(0.01f, 0.03f));
        meshRenderer.transform.localPosition = shake;

    }

}
