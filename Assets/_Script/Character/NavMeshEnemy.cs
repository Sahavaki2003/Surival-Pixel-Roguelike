
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using System;

public class NavMeshEnemy : MonoBehaviour
{
    [SerializeField]private Transform Target;
    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private float actionDistance = 2f;
    public static event Action Attack, NoAttack;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    void Update()
    {
        this.GetDistance();
    }

    private void GetDistance()
    {
        if(Target == null) return;
        float distance = Vector3.Distance(transform.position,Target.position);

        if(distance <= actionDistance)
        {
            this.OnAttack();
            agent.updatePosition = false;
            agent.SetDestination(transform.position);

        }
        else if(distance > actionDistance)
        {
            this.NoAccatck();
            agent.updatePosition = true;
            agent.SetDestination(Target.position);
        }
    }
    private void OnAttack()
    {
        Attack?.Invoke();
        Debug.Log("Enemy thông báo có thể tấn công");
    }
    private void NoAccatck()
    {
        NoAttack?.Invoke();
        Debug.Log("Enemy thông báo không thể tấn công");
    }
}
