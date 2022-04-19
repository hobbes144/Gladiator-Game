using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AI_States
{
    PATROL_STATE, HUNT_STATE, RESET_STATE
}

public class enemyBase : MonoBehaviour
{

    Player_Equiped playerReference;
    

    [SerializeField] private float huntThreshold = 10f;
    [SerializeField] private float escapeThreshold = 20f;
    [SerializeField] private AI_States state = AI_States.PATROL_STATE;
    [SerializeField] private Transform patrolStart;
    [SerializeField] private Transform patrolEnd;
    [SerializeField] private Transform player;

    [Header("Emeny")]
    float enemyHealth = 100.0f;
    float enemyDamage = 10.0f;
    float attackRange = 2.5f;
    float attackCooldown = 5.0f;

    [Header("Emeny Attack")]
    bool inAttackRange = false;
    bool attacking = false;
    float attackTimer = 0.0f;

    private Transform moveTarget;
    private moveTo steering;

    //these are to ensure that the agent hunts for at least a second and doesnt just reset if on the tangent
    private float timer;
    private bool canLeaveHunt = false;
    [SerializeField] private float huntStickTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        steering = GetComponent<moveTo>();
        playerReference = GetComponent<Player_Equiped>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AI_States.PATROL_STATE:
                doPatrol();
                break;

            case AI_States.HUNT_STATE:
                doHunt();
                break;

            case AI_States.RESET_STATE:
                doReset();
                break;
        }

        if (Vector3.Distance(player.position, transform.position) > attackRange)
        {
            inAttackRange = true;
        }
        else
        {
            inAttackRange = false;
        }

        if (inAttackRange && !attacking && (attackTimer >= attackCooldown))
        {
            attackCycle();
        }

        attackTimer += Time.deltaTime;
    }

    private void doPatrol()
    {
        //Start point walk to end point and back to start repeat
        float distanceToTarget = Vector3.Distance(transform.position, moveTarget.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= huntThreshold)
        {
            state = AI_States.HUNT_STATE;
            steering.setTarget(player);
            moveTarget = player;
        }
        else
        {
            if (distanceToTarget >= 1f)
            {
                //steering.setTarget(moveTarget);
            }
            else
            {
                if (moveTarget == patrolStart)
                {
                    moveTarget = patrolEnd;
                }
                else
                {
                    moveTarget = patrolStart;
                }
                steering.setTarget(moveTarget);
            }
        }
    }

    private void doHunt()
    {
        float distanceToTarget = Vector3.Distance(transform.position, player.position);
        if (distanceToTarget > escapeThreshold && canLeaveHunt)
        {
            state = AI_States.RESET_STATE;
            canLeaveHunt = false;
        }//else hunt down the player
        else
        {
            timer += Time.deltaTime;
            if (timer >= huntStickTime)
            {
                timer = 0;
                canLeaveHunt = true;
            }
        }
    }

    private void doReset()
    {
        float distanceToTarget = Vector3.Distance(transform.position, patrolStart.position); //how far from the start point am I
        if (distanceToTarget >= 1f)
        {
            steering.setTarget(patrolStart);
            moveTarget = patrolStart;
        }
        else
        {
            state = AI_States.PATROL_STATE;
            moveTarget = patrolEnd;
            steering.setTarget(patrolEnd);
        }
    }

    void attackCycle()
    {
        attacking = true;
        //play attack animation**
        playerReference.playerDamaged(enemyDamage);
        Debug.Log("Enemy is hit");

        attackTimer = 0.0f;
        attacking = false;

    }





}
