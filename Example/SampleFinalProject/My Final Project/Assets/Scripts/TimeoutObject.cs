using System.Collections;
using UnityEngine;

public class TimerObject : MonoBehaviour
{
    [SerializeField] float interval;

    bool isRendererActive => meshRenderer.enabled;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        StartCoroutine(TimeoutCoroutine());
    }

    private IEnumerator TimeoutCoroutine()
    {
        yield return new WaitForSeconds(interval);
        Destroy(gameObject);
    }
}
