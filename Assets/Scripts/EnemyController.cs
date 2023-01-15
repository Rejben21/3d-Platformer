using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject PatrolPoints;
    public Transform[] patrolPoints;
    public int curPatrolPoint;

    private NavMeshAgent agent;
    private Animator anim;

    public enum AIState
    {
        isIdle,
        isPatroling,
        isChasing,
        isAttacking
    };

    public AIState currentState;

    public float waitAtPoint = 2f;
    private float waitCounter;

    private float distanceToPlayer;

    public float viewDistance;

    public float attackRange;
    public float timeBetwenAttacks = 2f;
    private float attackCounter;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        waitCounter = waitAtPoint;

        PatrolPoints.transform.parent = null;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        switch (currentState)
        {
            case AIState.isIdle:

                IdleState();

                break;

            case AIState.isPatroling:

                PatrolingState();

                break;

            case AIState.isChasing:

                ChacingState();

                break;

            case AIState.isAttacking:

                AttackingState();

                break;
        }
    }

    public void AttackingState()
    {
        transform.LookAt(PlayerController.instance.transform.position, Vector3.up);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

        attackCounter -= Time.deltaTime;
        if(attackCounter <= 0)
        {
            if(distanceToPlayer <= attackRange)
            {
                anim.SetTrigger("Attack");
                attackCounter = timeBetwenAttacks;
            }
            else
            {
                currentState = AIState.isIdle;
                waitCounter = waitAtPoint;

                agent.isStopped = false;
            }
        }
    }

    public void ChacingState()
    {
        agent.SetDestination(PlayerController.instance.transform.position);
        anim.SetBool("IsMoving", true);

        if (distanceToPlayer <= attackRange)
        {
            currentState = AIState.isAttacking;

            anim.SetTrigger("Attack");
            anim.SetBool("IsMoving", false);

            agent.velocity = Vector3.zero;
            agent.isStopped = true;

            attackCounter = timeBetwenAttacks;
        }

        if(distanceToPlayer > viewDistance)
        {
            currentState = AIState.isIdle;
            waitCounter = waitAtPoint;

            agent.velocity = Vector3.zero;
            agent.SetDestination(transform.position);
        }
    }

    public void IdleState()
    {
        if (distanceToPlayer <= viewDistance)
        {
            currentState = AIState.isChasing;
        }
        else
        {
            anim.SetBool("IsMoving", false);

            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
            }
            else
            {
                currentState = AIState.isPatroling;
                agent.SetDestination(patrolPoints[curPatrolPoint].position);
            }
        }
    }

    public void PatrolingState()
    {
        if (distanceToPlayer <= viewDistance)
        {
            currentState = AIState.isChasing;
        }
        else
        {
            anim.SetBool("IsMoving", true);

            if (agent.remainingDistance <= .2f)
            {
                curPatrolPoint++;
                if (curPatrolPoint >= patrolPoints.Length)
                {
                    curPatrolPoint = 0;
                }

                currentState = AIState.isIdle;
                waitCounter = waitAtPoint;
            }
        }
    }
}
