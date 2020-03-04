using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    private MapManager mm;
    private Transform playerTransform;
    private EnemyManager em;

    void Awake()
    {
        mm = FindObjectOfType<MapManager>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        em = GetComponentInParent<EnemyManager>();
    }

    void FixedUpdate()
    {
        if (playerTransform.position.z > transform.position.z)
        {
            mm.loadNext(playerTransform.position + new Vector3(0, 0, 20));
            em.SpawnEnemy();
            enabled = false;
        }
    }
}