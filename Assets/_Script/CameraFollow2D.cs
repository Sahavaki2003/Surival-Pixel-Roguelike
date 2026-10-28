using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]private Transform Target;
    [Header("Camera Setting")]
    [SerializeField]private float SpeedCamera = 0.15f;
    [SerializeField]private Vector2 Offset = Vector2.zero;

    private Vector3 currentVelocity;
    private void LateUpdate()
    {
        if (Target == null) return;

        Vector3 targetPosition = new Vector3( Target.position.x + Offset.x, Target.position.y + Offset.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, SpeedCamera);
    }
}
