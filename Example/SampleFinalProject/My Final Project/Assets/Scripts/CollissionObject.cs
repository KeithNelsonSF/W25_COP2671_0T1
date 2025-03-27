using UnityEngine;

public class CollissionObject : MonoBehaviour
{
    [SerializeField] float collisionDamage = 0.2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            ScoreManager.Instance.OnCollissionDamge.Invoke(collisionDamage);
        }
    }
}
