using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    private MapManager mm;
    private Transform playerTransform;

    void Awake()
    {
        mm = FindObjectOfType<MapManager>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    void FixedUpdate()
    {
        if (playerTransform.position.z > transform.position.z)
        {
            mm.loadNext(playerTransform.position + new Vector3(0, 0, 20));
            enabled = false;
        }
    }
}