using UnityEngine;

public class LightPole : MonoBehaviour
{
    private bool lightPoleTouched;

    void Start()
    {
        GameManager.Instance.lightPolesInScene++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (lightPoleTouched) return;

        if (collision.collider.tag == "Player")
        {
            lightPoleTouched = true;
            GameManager.Instance.lightPolesTouched++;
        }
    }
}
