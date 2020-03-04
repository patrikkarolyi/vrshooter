using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints;

    [SerializeField] private GameObject enemyPrefab;

    private List<GameObject> createdEnemies;

    private void Start()
    {
        createdEnemies = new List<GameObject>();
    }

    public void SpawnEnemy()
    {
        Transform playerTransform = FindObjectOfType<Camera>().transform;

        foreach (SpawnPoint sp in spawnPoints)
        {
            GameObject obj = Instantiate(enemyPrefab, sp.initPoint.position, Quaternion.identity);
            obj.transform.parent = transform.parent;

            EnemyMovement em = obj.GetComponent<EnemyMovement>();
            em.cp = sp.goalPoints;
            em.target = playerTransform;

            createdEnemies.Add(obj);
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject enemy in createdEnemies)
        {
            Destroy(enemy);
        }
    }

    public void OnEnemyDiedEvent()
    {
        GameObject obj = Instantiate(enemyPrefab, spawnPoints.First().initPoint.position, Quaternion.identity);
        obj.GetComponent<EnemyMovement>().target = spawnPoints.First().goalPoints[0];
    }
}