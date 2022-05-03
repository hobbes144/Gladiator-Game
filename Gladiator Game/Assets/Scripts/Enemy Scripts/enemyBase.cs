using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AI_States
{
    HUNT_STATE, GOver_STATE, HIT_STATE, ATTACK_STATE, DEAD_STATE
}

public class enemyBase : MonoBehaviour
{

    private Player_Equiped playerReference;
    private spawnerController spawnController;

    [SerializeField] private GameObject spawnControllerObject;
    [SerializeField] private AI_States state = AI_States.HUNT_STATE;
    [SerializeField] private Transform selfLocation;
    [SerializeField] private Transform playerTrans;

    [Header("Enemy")]
    [SerializeField] float enemyHealth = 100.0f;
    [SerializeField] float enemyCurrHealth = 100.0f;
    [SerializeField] float enemyDamage = 10.0f;
    [SerializeField] float enemyKnockbackPower = 3;
    [SerializeField] float attackRange = 5.0f;
    [SerializeField] float attackCooldown = 3.0f;
    [SerializeField] float enemySpeed = 3.5f;
    [SerializeField] GameObject enemyAttackTrigger;

    [Header("Power-Ups")]
    [SerializeField] private GameObject healthPU;
    [SerializeField] private GameObject armorPU;
    [SerializeField] private GameObject speedPU;
    [SerializeField] private GameObject meleePU;
    [SerializeField] private GameObject rangedPU;

    bool attacking = false;

    //private Transform moveTarget;
    private moveTo steering;
    private float distanceToTarget;
    private Rigidbody rb;
    private Animator animator;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Enemies");
        spawnControllerObject = GameObject.FindWithTag("GameController");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = enemySpeed;

        spawnController = spawnControllerObject.GetComponent<spawnerController>();
        playerReference = GameObject.FindWithTag("Player").GetComponent<Player_Equiped>();
        playerTrans = playerReference.gameObject.transform;

        rb = gameObject.GetComponent<Rigidbody>();

        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isDead", false);

        selfLocation = gameObject.transform;
        isDead = false;

        steering = GetComponent<moveTo>();
    }

    // Update is called once per frame
    void Update()
    {
        //selfLocation = gameObject.transform;

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
            case AI_States.DEAD_STATE:
                doDead();
                break;
        }

        //print("State: " + state);

    }

    //-----------STATE FUNCTIONS------------
    private void doHunt()
    {
        if (!isDead)
        {
            steering.setTarget(playerTrans);
            //print("Dist to Target: " + distanceToTarget);

            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);

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
        }
    } // end doHunt()
    private void doGOver()
    {
        steering.setTarget(selfLocation);

        //animator.SetBool("isAttacking", true);

    } // end doGOver()
    private void doHit()
    {
        steering.setTarget(selfLocation);

        if (distanceToTarget >= attackRange)
        {
            state = AI_States.HUNT_STATE;
            StopCoroutine(enemyAttacking());
        }

        if (isDead)
        {
            state = AI_States.DEAD_STATE;
        }

        if (playerReference.playerDead)
        {
            state = AI_States.GOver_STATE;
        }//else hunt down the player
    }
    private void doAttack()
    {
        steering.setTarget(selfLocation);

        animator.SetBool("isAttacking", true);

        if (!attacking)
        {
            print("Enemying is Attacking");
            StartCoroutine(enemyAttacking());
        }

        if (distanceToTarget > attackRange && !isDead)
        {
            StopCoroutine(enemyAttacking());
            animator.SetBool("isAttacking", false);
            state = AI_States.HUNT_STATE;
        }

        if (playerReference.playerDead)
        {
            state = AI_States.GOver_STATE;
        }//else hunt down the player

    } //end doAttack();
    private void doDead()
    {
        steering.setTarget(selfLocation);
    }


    //----------HELPER FUNCTIONS-------------
    public void enemyHit(float knockback, float damage)
    {
        if (enemyCurrHealth > 0) {
            StopCoroutine(enemyAttacking());
            attacking = false;
            animator.SetTrigger("isHit");
            state = AI_States.HIT_STATE;
            StartCoroutine(enemyHitCo());

            enemyCurrHealth -= damage;
            rb.AddForce(-1 * transform.forward * knockback, ForceMode.Impulse);

            if (enemyCurrHealth <= 0)
            {
                //enemy dies
                spawnController.enemyDeadCount += 1;
                print("Enemy Has Died");
                isDead = true;
                state = AI_States.DEAD_STATE;
                animator.SetBool("isDead", true);
                StartCoroutine(enemyDeath());
            }
        }
    }
    public void dropChance()
    {
        print("Drop Chance Run");

        float chance = Random.Range(1, 10);
        if (chance > 6)
        {
            print("Item has been dropped");
            var position = new Vector3(transform.position.x, 0.25f, transform.position.z);
            float chancePU = Random.Range(1, 5);
            GameObject itemPref = null;
            
            switch (chancePU)
            {
                case 1:
                    itemPref = healthPU;
                    break;
                case 2:
                    itemPref = armorPU;
                    break;
                case 3:
                    itemPref = speedPU;
                    break;
                case 4:
                    itemPref = meleePU;
                    break;
                case 5:
                    itemPref = rangedPU;
                    break;
            }

            Instantiate(itemPref, position, Quaternion.identity);
        }
    }

    //---------------CoRountines------------

    IEnumerator enemyHitCo()
    {
        //play hit animation
        yield return new WaitForSeconds(1); // wait for hit animation to finish
        //Stop the Agent to prevent recoil

        state = AI_States.HUNT_STATE;
    }

    IEnumerator enemyAttacking()
    {
        attacking = true;
        //play attack animation
        yield return new WaitForSeconds(0.5f);

        //playerReference.playerDamaged(enemyDamage);
        GameObject eAT = Instantiate(enemyAttackTrigger, gameObject.transform);
        print("Enemy Attacking With " + enemyDamage + " damage and " + enemyKnockbackPower + " Knockback");
        eAT.GetComponent<enemyAttackTrigger>().setEffects(enemyDamage, enemyKnockbackPower);
        eAT.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(1);
        attacking = false;
    }

    IEnumerator enemyDeath()
    {
        yield return new WaitForSeconds(4);
        dropChance();
        Destroy(gameObject);
    }
}
