using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints;

    [SerializeField] private GameObject enemyPrefab;

    private Boolean temp = false;

    public void SpawnEnemy( int spawnPointIndex = 0)
    {
        Transform playerTransform = FindObjectOfType<PlayerMovement>().transform;

        GameObject obj = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].initPoint.position, Quaternion.identity);
        obj.transform.parent = transform.parent;

        EnemyMovement em = obj.GetComponent<EnemyMovement>();
        em.cp = spawnPoints[spawnPointIndex].goalPoints;
        em.target = playerTransform;
    }

    public void OnEnemyDiedEvent()
    {
        if (temp)
        {
            GameObject obj = Instantiate(enemyPrefab, spawnPoints.First().initPoint.position, Quaternion.identity);
            obj.GetComponent<EnemyMovement>().target = spawnPoints.First().goalPoints[0];
            temp = false;
        }

        else
        {
            GameObject obj = Instantiate(enemyPrefab, spawnPoints.Last().goalPoints[0].position, Quaternion.identity);
            obj.GetComponent<EnemyMovement>().target = spawnPoints.First().goalPoints[0];
            temp = true;
        }
    }
}