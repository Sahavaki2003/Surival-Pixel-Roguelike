using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]private Transform TargetPlayer;
    
    [Header("Camera Setting")]
    [SerializeField]private float SpeedCamera = 0.15f;
    [SerializeField]private Vector2 Offset = Vector2.zero;

    private Vector3 currentVelocity;
    
    //tính toán vị trí camera muốn hướng tới targetPosition, Di chuyển camera mượt mà đến vị trí được tính toán targetPosition
    private void LateUpdate()
    {
        if (TargetPlayer == null) return;

        Vector3 targetPosition = new Vector3(TargetPlayer.position.x + Offset.x, TargetPlayer.position.y + Offset.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, SpeedCamera);
    }
}
