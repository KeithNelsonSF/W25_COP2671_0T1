using System.Collections;
using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    [SerializeField] float blinkInterval = 0.5f;

    bool isRendererActive => meshRenderer != null && meshRenderer.enabled;

    MeshRenderer meshRenderer;
    Coroutine blinkCoroutine = null;

    private void OnEnable()
    {
        blinkCoroutine = StartCoroutine(BlinkCoroutine());
    }

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
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
                if (meshRenderer != null)
                    meshRenderer.enabled = true;
            }            
            yield return new WaitForSeconds(blinkInterval);
        }
        yield return null;
    }
}
