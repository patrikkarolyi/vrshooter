using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField]
    private float updateTime;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speedPercentage = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent",speedPercentage,updateTime,Time.deltaTime);
    }
}
