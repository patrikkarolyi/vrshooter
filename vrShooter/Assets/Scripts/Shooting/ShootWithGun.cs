using Valve.VR;
using UnityEngine;

public class ShootWithGun : MonoBehaviour
{
    public float damage = 30f;
    public float range = 100f;
    public float speed = 10;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public SteamVR_Input_Sources handType;

    void Update()
    {


        if (SteamVR_Input.GetStateDown("InteractUI", handType))
        {
            shoot();
        }

    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity) as GameObject;
        Rigidbody brb = bullet.GetComponent<Rigidbody>();

        Vector3 direction = firePoint.position - transform.position ;
        brb.velocity = direction * speed;

        Destroy(bullet, 2f);
    }
}
