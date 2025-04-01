using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [Header("Set Info About Enemy")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _fireRate = 0.3f;
    [SerializeField] private float _health = 10;
    [SerializeField] private int score = 100;

    private BoundsCheck check;

    private void Awake()
    {
        check = GetComponent<BoundsCheck>();
    }

    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }

    private void Update()
    {

        Move();
    }

    protected virtual void Move()
    {
        if(check != null && !check.isOnScreen)
        {
            Destroy(gameObject);
        }
        Vector3 vector3 = pos;
        vector3.y -= _speed * Time.deltaTime;
        pos = vector3;
    }
}
