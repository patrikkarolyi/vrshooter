using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] 
    private List<Transform> spawnPoints;
    
    [SerializeField] 
    private GameObject enemyPrefab;


    public void OnEnemyDiedEvent()
    {
        Instantiate(enemyPrefab, spawnPoints.First().position, Quaternion.identity);
    } 
    
    
}
