
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using System;

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
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
        {
            Target = playerObj.transform;
        }
    }
    void Update()
    {
        this.GetDistance();
    }

    //tính toán khoảng cách giữ player và enemy, nếu mà <= vào actionDistance thì dừng lại >= thì đi tiếp
    private void GetDistance()
    {
        if(Target == null) return;
        float distance = Vector3.Distance(transform.position,Target.position);

        if(distance <= actionDistance)
        {

            agent.updatePosition = false;
            agent.SetDestination(transform.position);

        }
        else if(distance > actionDistance)
        {
            agent.updatePosition = true;
            agent.SetDestination(Target.position);
        }
    }
}
