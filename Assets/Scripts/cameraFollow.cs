using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3 (0,0,-10);
    [Range(2,10)]
    public float smoothing = 8f;

    private void Start()
    {
        target = GameObject.Find("PlayerSprite").transform;
    }

    void FixedUpdate()
    {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
            transform.position = smoothPosition;
    }
}
