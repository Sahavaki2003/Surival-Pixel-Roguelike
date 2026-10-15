
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    [SerializeField]private Transform Target;
    [SerializeField]private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void OnEnable()
    {
        Target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        agent.SetDestination(Target.position);
    }
}
