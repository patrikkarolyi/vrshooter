
using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private Transform[] cp;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bullet;
    private NavMeshAgent agent;
    private bool isMoving;
    private bool isShooting;
    private int goalCPIndex;
    

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        isMoving = false;
        isShooting = false;
        goalCPIndex = 0;
    }

    void Update()
    {
        if (isShooting) return;
        if (!isMoving)
        {
            if (goalCPIndex<cp.Length)
            {
                agent.SetDestination(cp[goalCPIndex].position);
                isMoving = true;
            }
            else
            {
                agent.enabled = false;
                rotateInDirectionOfCamera();
                InvokeRepeating("DoActionAtLastCp", 1f, 1f); 
                isShooting = true;
            }
        }
        else
        {
            //if (Vector3.Distance(cp[goalCPIndex].position, transform.position) < 2f)
            if(agent.remainingDistance <= 0)
            {
                Debug.Log("Stopped");
                isMoving = false;
                goalCPIndex++;
            }
        }
    }

    void rotateInDirectionOfCamera()
    {
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
    
    void DoActionAtLastCp()
    {
        //TODO in gun component
        GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = target.transform.position - firePoint.position;
        Destroy(projectile, 3f);
    }
    
    
    
    
}
