using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private Transform target;

    private Boolean temp = false;


    public void OnEnemyDiedEvent()
    {
        if (temp)
        {
            GameObject obj = Instantiate(enemyPrefab, spawnPoints.First().position, Quaternion.identity);
            obj.GetComponent<EnemyMovement>().target = target;
            temp = false;
        }

        else
        {
            GameObject obj = Instantiate(enemyPrefab, spawnPoints.Last().position, Quaternion.identity);
            obj.GetComponent<EnemyMovement>().target = target;
            temp = true;
        }
    }
}