using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] cp;
    [SerializeField] public Transform target;
    
    [SerializeField] private GameObject bullet;
    private NavMeshAgent agent;
    private bool isMoving;
    private bool isShooting;
    private Transform firePoint;
    private int goalCPIndex;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        firePoint = transform.GetChild(2).GetChild(2).GetChild(0).GetChild(0).GetChild(2).transform;
        isMoving = false;
        isShooting = false;
        goalCPIndex = 0;
    }

    void Update()
    {

        if (isShooting)
        {
            return;
        }
        if (!isMoving)
        {
            if (goalCPIndex < cp.Length)
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
            if (agent.remainingDistance <= 0)
            {
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