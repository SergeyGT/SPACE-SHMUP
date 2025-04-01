using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set In inspector")]
    [SerializeField]private float _radius;

    private float camHeight;
    private float camWidth;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if(pos.x > camWidth - _radius)
        {
            pos.x = camWidth - _radius;
        }
        if (pos.x < -camWidth - _radius)
        {
            pos.x = -camWidth - _radius;
        }
        if (pos.y > camHeight - _radius)
        {
            pos.x = camHeight - _radius;
        }
        if (pos.y < -camHeight - _radius)
        {
            pos.x = -camHeight - _radius;
        }

        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawCube(Vector3.zero, boundSize);
    }
}
