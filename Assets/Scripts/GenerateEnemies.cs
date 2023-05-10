using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject theEnemy;
    public float spawnChance;

    [Header("Raycast settings")]
    public float distanceBetweenChecks;
    public float heightOfCheck = 10f, rangeOfCheck = 30f;
    public LayerMask layerMask;
    public Vector2 positivePosition, negativePosition;


    private void Start()
    {
        SpawnResources();
    }
    void SpawnResources()
    {
        for (float x = negativePosition.x; x < positivePosition.x; x+= distanceBetweenChecks)
        {
            for(float y = negativePosition.y; y < positivePosition.y; y+= distanceBetweenChecks)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
                if (Physics2D.Raycast(new Vector2(x,y), Vector2.down, RaycastHit2D hit,rangeOfCheck, layerMask))
                {
                    if(spawnChance > Random.Range(0, 101))
                    {
                        Debug.Log("Instantiate Bro");
                        Instantiate(theEnemy, hit.point, Quaternion.identity, transform);
                    }
                }
            }
        }
    }

}