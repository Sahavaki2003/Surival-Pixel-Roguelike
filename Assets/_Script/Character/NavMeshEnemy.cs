
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    [SerializeField] private Transform player;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        // Cố định di chuyển trên mặt phẳng XY của game 2D
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        TargetPlayer();
    }

    private void TargetPlayer()
    {
        if (player == null) return;
        if (agent == null) return;

        // Chỉ tìm đường khi Agent đang hoạt động
        // và đã nằm trên NavMesh
        if (!agent.isActiveAndEnabled) return;
        if (!agent.isOnNavMesh) return;

        Vector3 targetPosition = player.position;

        // Giữ nguyên tọa độ Z của Enemy
        targetPosition.z = transform.position.z;

        agent.SetDestination(targetPosition);
    }
}
