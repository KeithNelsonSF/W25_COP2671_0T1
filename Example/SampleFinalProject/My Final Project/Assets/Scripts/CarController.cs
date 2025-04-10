using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class CarController : MonoBehaviour
{
    AudioSource _audioSource;
    NavMeshAgent _agent;    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();        
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _agent.speed = GameManager.Instance.carSpeed;
    }
    private void Update()
    {
        var forwardInput = GameManager.Instance.driveDirections.y;
        var turnInput = GameManager.Instance.driveDirections.x;

        var pitch = Mathf.Clamp(1 + Mathf.Abs(forwardInput), 1, 2);
        _audioSource.pitch = pitch;        

        _agent.Move(transform.forward * forwardInput * _agent.speed * Time.deltaTime);
        transform.Rotate(Vector3.up, turnInput * _agent.angularSpeed * Time.deltaTime);
    }
}
 