using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBase : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float enemyMoveSpeed = 5.0f;
    [SerializeField] float minDistance = 1.0f;

    float attackRange = 2.5f; //threshold for attack (differing for each enemy)
    bool inAttackRange = false; //check threshold
    bool attacking = false;

    float attackCooldown = 0.0f;

    [SerializeField] Transform _destination;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= minDistance);
        {
            transform.position += transform.forward * enemyMoveSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(player.position, transform.position) > attackRange) 
        {
            inAttackRange = true;
        }
        else
        {
            inAttackRange = false;
        }

        if (inAttackRange && !attacking && (attackCooldown <= 0.0f))
        {
            attackCycle();
        }

        attackCooldown -= Time.deltaTime;
    }

    void attackCycle()
    {
        attacking = true;
        //play attack animation**
        //player.health -= 10; //not fixed value

        attackCooldown = 5.0f;

        attacking = false;
        
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            
        }
    }
}
