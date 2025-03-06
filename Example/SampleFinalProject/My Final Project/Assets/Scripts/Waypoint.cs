using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float height;
    
    bool isRendererActive => meshRenderer.enabled;    
    MeshRenderer meshRenderer;
    

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name);
    }
}
