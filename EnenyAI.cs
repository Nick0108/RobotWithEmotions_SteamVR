using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnenyAI : MonoBehaviour {

    public enum EmeryState
    {
        Runaway,
        MovingToPoint,
        Attack,
        Death
    }
    public NavMeshAgent Agent;
    public Transform player;
    public Transform focusPoint;
    public EmeryState currentState;
    public float AttackInterval = 1.0f;
    public PlayerHealth playerHealth;

    private Vector3 DestinationVector3;
    private Animator animator;
    private float distance;
    private EnemyHealth HP;
    private float AttackTimer;

    // Use this for initialization
    void Start () {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        HP = GetComponent<EnemyHealth>();
        AttackTimer = 0;
    }

	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(player.position, focusPoint.position);
        UpdateCurrentState();
        AttackTimer += Time.deltaTime;
    }

    //Check if reach destination
    private bool isAgentDone()
    {
        return !Agent.pathPending && Agent.remainingDistance <= Agent.stoppingDistance;
    }

    private void UpdateCurrentState()
    {
        switch (currentState)
        {
            case EmeryState.Runaway:
                RunAway();
                break;
            case EmeryState.MovingToPoint:
                MovingTo();
                break;
            case EmeryState.Attack:
                Attack();
                break;
            case EmeryState.Death:
                Dead();
                break;
        }
    }

    void RunAway()
    {
        if(!HP.Alive)
        {
            currentState = EmeryState.Death;
            Agent.ResetPath();
            return;
        }
        if (distance > 3)
        {
            currentState = EmeryState.MovingToPoint;
            Agent.ResetPath();
            return;
        }
        /*else if (Vector3.Distance(transform.position, focusPoint.position) < 1f)
        {
            currentState = EmeryState.Attack;
            Agent.ResetPath();
            return;
        }*/
        if (isAgentDone())
        {
            Agent.ResetPath();
            float TempX = transform.position.x + Random.Range(-2.0f, 2.5f);
            float TempY;
            if (TempX < 6) TempX = 6.0f;
            if (TempX > 12)
            {
                Vector3 newPos = new Vector3(Random.Range(12.0f, 23.0f), 0, Random.Range(-9f, -3f));
                Agent.SetDestination(newPos);
                //Debug.Log(newPos);
                animator.SetFloat("Forward", 1.0f);
            }else
            {
                if (player.position.z > -6)
                    TempY = -Mathf.Sqrt(9 - Mathf.Pow(TempX - 9, 2)) - 6;
                else
                    TempY = Mathf.Sqrt(9 - Mathf.Pow(TempX - 9, 2)) - 6;
                Vector3 newPos = new Vector3(TempX, 0, TempY);
                Agent.SetDestination(newPos);
                //Debug.Log(newPos);
                animator.SetFloat("Forward", 1.0f);
            }
        }
    }

    void MovingTo()
    {
        if (!HP.Alive)
        {
            currentState = EmeryState.Death;
            Agent.ResetPath();
            return;
        }
        if (distance <= 3)
        {
            currentState = EmeryState.Runaway;
            Agent.ResetPath();
            return;
        }
        else if (Vector3.Distance(transform.position, focusPoint.position) < 1f)
        {
            currentState = EmeryState.Attack;
            Agent.ResetPath();
            return;
        }
        Agent.SetDestination(focusPoint.position);
        animator.SetFloat("Forward", 1.0f);
    }

    void Attack()
    {
        if (!HP.Alive)
        {
            currentState = EmeryState.Death;
            Agent.ResetPath();
            return;
        }
        if (distance <= 3)
        {
            currentState = EmeryState.Runaway;
            Agent.ResetPath();
            return;
        }
        animator.SetFloat("Forward", 0.0f);
        animator.SetBool("Eat",true);
        if (AttackTimer > AttackInterval)
        {
            playerHealth.GetHurt();
            AttackTimer = 0;
        }
    }

    void Dead()
    {
        animator.SetFloat("Forward", 0.0f);
        animator.SetBool("Death", true);
    }
}
