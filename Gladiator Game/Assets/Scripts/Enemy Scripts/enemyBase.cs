using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AI_States
{
    PATROL_STATE, HUNT_STATE, GOver_STATE
}

public class enemyBase : MonoBehaviour
{

    //Player_Equipped playerReference;
    bool GameOver = false;

    [SerializeField] private AI_States state = AI_States.HUNT_STATE;
    [SerializeField] private Transform selfLocation;
    [SerializeField] private Transform player;

    [Header("Emeny")]
    [SerializeField] float enemyHealth = 100.0f;
    [SerializeField] float enemyCurrHealth = 100.0f;
    [SerializeField] float enemyDamage = 10.0f;
    [SerializeField] float attackRange = 5.0f;
    [SerializeField] float attackCooldown = 3.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {

            case AI_States.HUNT_STATE:
                doHunt();
                break;

            case AI_States.GOver_STATE:
                doGOver();
                break;
        }

        if (Vector3.Distance(player.position, transform.position) < attackRange)
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

    private void doHunt()
    {
        float distanceToTarget = Vector3.Distance(transform.position, player.position);
        if (GameOver)
        {
            state = AI_States.GOver_STATE;
        }//else hunt down the player
        else
        {
            
        }
    }

    private void doGOver()
    {
        if (GameOver)
        {
            steering.setTarget(selfLocation);
            moveTarget = selfLocation;
        }
        else
        {
            state = AI_States.HUNT_STATE;
            moveTarget = player;
            steering.setTarget(player);
        }
    }

    void attackCycle()
    {
        attacking = true;
        //play attack animation**
        //playerReference.playerDamaged(enemyDamage);
        Debug.Log("Enemy is hit");

        attackTimer = 0.0f;
        attacking = false;

    }

    public void enemyHit(float knockback, float damage)
    {



        enemyCurrHealth -= damage;


    }



}
