using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private Transform[] cp;
    private NavMeshAgent agent;
    private bool isMoving;
    private System.Random rand;
    private int goalCPIndex;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        isMoving = false;
        rand = new System.Random();
    }

    void Update()
    {


        if (!isMoving)
        {
            int i = rand.Next(cp.Length);
            goalCPIndex = i;
            agent.SetDestination(cp[i].position);
            isMoving = true;

        }
        else
        {
            Debug.Log(agent.velocity);
            if (Vector3.Distance(cp[goalCPIndex].position, transform.position) < 2f)
            {
                isMoving = false;
            }
        }

    }
}
