
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    [SerializeField]private Transform Target;
    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private float actionDistance = 2f;
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
        if(Target == null) return;
        float distance = Vector3.Distance(transform.position,Target.position);

        if(distance <= actionDistance)
        {
            agent.updatePosition = false;
            agent.SetDestination(transform.position);
            this.Attack();
        }
        else if(distance > actionDistance)
        {
            agent.updatePosition = true;
            agent.SetDestination(Target.position);
        }
    }

    private void Attack()
    {
        Debug.Log("quai thực hiên tấn công và truyền dame");
    }








}
