using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero S;

    [Header("Set specks Hero")]
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _rollMult = 0;
    [SerializeField] private float _pitchMult = 0;


    [Header("Set Dynamically")]
    public float _shieldLevel = 0;

    private void Awake()
    {
        if(S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Attempt to assign second Hero");
        }
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;

        pos.x += xAxis * _speed * Time.deltaTime;
        pos.y += yAxis * _speed * Time.deltaTime;

        transform.position = pos;

        transform.rotation = Quaternion.Euler(yAxis*_pitchMult, xAxis*_rollMult, 0);   
    }
}
