using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    

    public void Shoot(Transform target)
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Vector3 vt = calculateVelocityToShoot(target);

        projectile.GetComponent<Rigidbody>().velocity = vt;
        Destroy(projectile, 3f);
    }

    private Vector3 calculateVectorToShoot(Transform target)
    {
        Vector3 Vplayer = target.gameObject.GetComponentInParent<PlayerMovement>().direction * (Time.deltaTime + 1);
        Vector3 Splayer = target.position - firePoint.position ;
        
        //Splayer/timeToHit + Vplayer = Vbullet
        return Splayer / 2f + Vplayer;

    }
    private Vector3 calculateVelocityToShoot(Transform target)
    {
        Vector3 Vplayer = target.gameObject.GetComponentInParent<PlayerMovement>().direction * (Time.deltaTime + 1);
        Vector3 Splayer = target.position - firePoint.position ;
 
        //t = (TargetPos - FPPos).nmagn
        float t = Splayer.sqrMagnitude/8;
        
        //Vbullet = (TargetPos - FPPos) / t + Vplayer
        return Splayer/t + Vplayer;
    }
    
}
