using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    [Range(2,10)]
    public float smoothing;

    void FixedUpdate()
    {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
            transform.position = smoothPosition;
    }
}
