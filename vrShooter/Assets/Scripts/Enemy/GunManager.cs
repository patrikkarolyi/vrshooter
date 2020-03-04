using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private float timeToHit;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    

    public void Shoot(Transform target)
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = calculateVectorToShoot(target);
        Destroy(projectile, 3f);
    }

    private Vector3 calculateVectorToShoot(Transform target)
    {
        Vector3 Splayer = target.position - firePoint.position;
        Vector3 Vplayer = target.gameObject.GetComponentInParent<PlayerMovement>().direction * Time.deltaTime;
        
        //Splayer/timeToHit + Vplayer = Vbullet
        return Splayer / timeToHit + Vplayer;

    }
    
    
}
