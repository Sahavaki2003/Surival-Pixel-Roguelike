using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]private Transform target;
    [Header("Camera Setting")]
    [SerializeField]private float speedCamera = 0.15f;
    [SerializeField]private Vector2 offset = Vector2.zero;

    private Vector3 currentVelocity;
    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = new Vector3( target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, speedCamera);
    }
}
