using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AI_States
{
    HUNT_STATE, GOver_STATE, HIT_STATE, ATTACK_STATE
}

public class enemyBase : MonoBehaviour
{

    private Player_Equiped playerReference;

    [SerializeField] private AI_States state = AI_States.HUNT_STATE;
    [SerializeField] private Transform selfLocation;
    [SerializeField] private Transform playerTrans;

    [Header("Emeny")]
    [SerializeField] float enemyHealth = 100.0f;
    [SerializeField] float enemyCurrHealth = 100.0f;
    [SerializeField] float enemyDamage = 10.0f;
    [SerializeField] float attackRange = 5.0f;
    [SerializeField] float attackCooldown = 3.0f;

    [Header("Emeny Attack")]
    //bool inAttackRange = false;
    bool attacking = false;
    //float attackTimer = 0.0f;

    private Transform moveTarget;
    private moveTo steering;
    private float distanceToTarget;
    private Rigidbody rb;

    //these are to ensure that the agent hunts for at least a second and doesnt just reset if on the tangent
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindWithTag("Player").GetComponent<Player_Equiped>();
        playerTrans = playerReference.gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();

        steering = GetComponent<moveTo>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, playerTrans.position);

        switch (state)
        {

            case AI_States.HUNT_STATE:
                doHunt();
                break;
            case AI_States.GOver_STATE:
                doGOver();
                break;
            case AI_States.HIT_STATE:
                doHit();
                break;
            case AI_States.ATTACK_STATE:
                doAttack();
                break;
        }

        print("State: " + state);

    }

    private void doHunt()
    {
        steering.setTarget(playerTrans);
        //print("Dist to Target: " + distanceToTarget);

        if (distanceToTarget < attackRange)
        {
            //inAttackRange = true;
            state = AI_States.ATTACK_STATE;
        }
        else
        {
            //inAttackRange = false;
        }

        if (playerReference.playerDead)
        {
            state = AI_States.GOver_STATE;
        }//else hunt down the player
    } // end doHunt()

    private void doGOver()
    {
        steering.setTarget(null);

        /*
        if (playerReference.playerDead)
        {
            steering.setTarget(selfLocation);
            moveTarget = selfLocation;
        }
        else
        {
            state = AI_States.HUNT_STATE;
            moveTarget = playerTrans;
            steering.setTarget(playerTrans);
        }
        */

    } // end doGOver()

    private void doHit()
    {

    }
    private void doAttack()
    {
        if (!attacking)
        {
            print("Enemying is Attacking");
            StartCoroutine(enemyAttacking());
        }

    } //end doAttack();

    public void enemyHit(float knockback, float damage)
    {
        StopAllCoroutines();
        //stop animations
        state = AI_States.HIT_STATE;
        StartCoroutine(enemyHitCo());

        enemyCurrHealth -= damage;

        if (enemyCurrHealth <= 0)
        {
            //enemy dies
            Destroy(gameObject, 1);
        }
    }


    //---------------CoRountines------------

    IEnumerator enemyHitCo()
    {
        //play hit animation
        yield return new WaitForSeconds(1); // wait for hit animation to finish
        state = AI_States.HUNT_STATE;
    }

    IEnumerator enemyAttacking()
    {
        attacking = true;
        //play attack animation
        yield return new WaitForSeconds(1);
        rb.isKinematic = true;
        print("rb is Kinematic");
        rb.isKinematic = false;
        print("rb is not Kinematic");
        playerReference.playerDamaged(enemyDamage);
        attacking = false;
        if (distanceToTarget > attackRange) 
        {
            state = AI_States.HUNT_STATE;
        }
    }
}
