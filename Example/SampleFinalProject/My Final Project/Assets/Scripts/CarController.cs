using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour
{
    static string Horizontal = nameof(Horizontal);
    static string Vertical = nameof(Vertical);

    AudioSource _audioSource;
    NavMeshAgent _agent;    

    float forwardInput => Input.GetAxis(Vertical);
    float turnInput => Input.GetAxis(Horizontal);

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        var pitch = Mathf.Clamp(1 + Mathf.Abs(forwardInput), 1, 2);
        _audioSource.pitch = pitch;        

        _agent.Move(transform.forward * forwardInput * _agent.speed * Time.deltaTime);
        transform.Rotate(Vector3.up, turnInput * _agent.angularSpeed * Time.deltaTime);
    }
}
 