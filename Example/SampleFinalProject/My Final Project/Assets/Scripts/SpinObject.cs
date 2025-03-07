using UnityEngine;

public class SpinObject : MonoBehaviour
{   
    [SerializeField] float spinSpeed = 0.5f;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime * 100f);
    }
}
