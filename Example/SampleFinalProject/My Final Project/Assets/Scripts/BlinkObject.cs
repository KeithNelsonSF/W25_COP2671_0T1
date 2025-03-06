using System.Collections;
using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    [SerializeField] float blinkInterval = 0.5f;

    bool isRendererActive => meshRenderer.enabled;
    MeshRenderer meshRenderer;
    Coroutine blinkCoroutine = null;

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        blinkCoroutine = StartCoroutine(BlinkCoroutine());
    }
    private IEnumerator BlinkCoroutine()
    {
        while (gameObject.activeSelf)
        {
            if (isRendererActive)
            {
                meshRenderer.enabled = false;
            }
            else
            {
                meshRenderer.enabled = true;
            }            
            yield return new WaitForSeconds(blinkInterval);
        }
        yield return null;
    }
}
