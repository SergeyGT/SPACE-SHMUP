using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float _rotationPerSecond = 0.2f;

    private Material _mat;
    private int _levelShown;

    private void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if(Hero.S._shieldLevel != _levelShown)
        {
            _levelShown = Mathf.FloorToInt(Hero.S._shieldLevel);
            _mat.mainTextureOffset = new Vector2((float)0.2 * _levelShown, 0);
        }

        float rZ = -(_rotationPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
