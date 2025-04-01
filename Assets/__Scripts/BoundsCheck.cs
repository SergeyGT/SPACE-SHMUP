using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set In inspector")]
    [SerializeField] public float _radius;
    [SerializeField] private bool _keepOnScreen = true;

    public bool isOnScreen = true;
    public float camHeight;
    public float camWidth;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;

        if(pos.x > camWidth - _radius)
        {
            pos.x = camWidth - _radius;
            isOnScreen = false;
        }
        if (pos.x < -camWidth - _radius)
        {
            pos.x = -camWidth - _radius;
            isOnScreen = false;
        }
        if (pos.y > camHeight - _radius)
        {
            pos.x = camHeight - _radius;
            isOnScreen = false;
        }
        if (pos.y < -camHeight - _radius)
        {
            pos.x = -camHeight - _radius;
            isOnScreen = false;
        }

        if(_keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
        }
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawCube(Vector3.zero, boundSize);
    }
}
