using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float height;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}
