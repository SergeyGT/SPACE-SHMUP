using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main instance;

    public GameObject[] enemyPrefabs;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;

    private BoundsCheck boundsCheck;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Main Object is exists");
        }
        else
        {
            instance = this;
            boundsCheck = GetComponent<BoundsCheck>();
            Invoke("SpawnEnemies", 1f/enemySpawnPerSecond);
        }
    }

    private void SpawnEnemies()
    {
        int ndx = Random.Range(0, enemyPrefabs.Length);
        GameObject go = Instantiate(enemyPrefabs[ndx]);

        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>()!=null )
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>()._radius);
        }

        Vector3 pos = Vector3.zero;

        float xMin = -boundsCheck.camWidth + enemyPadding;
        float xMax = boundsCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax);
        pos.y = boundsCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        Invoke("SpawnEnemies", 1f / enemySpawnPerSecond);
    }
}
