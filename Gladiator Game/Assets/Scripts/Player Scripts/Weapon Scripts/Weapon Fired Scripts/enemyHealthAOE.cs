using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthAOE : MonoBehaviour
{

    [Header("AOE Effect")]
    [SerializeField] private float healthDelta;
    [SerializeField] private float knockbackPower;
    [SerializeField] private float radius;
    [SerializeField] private GameObject particleObject;
    [SerializeField] private LayerMask enemyLayer;

    [Header("Looping Input")]
    [SerializeField] private bool looping;
    [SerializeField] private float repetitions;
    [SerializeField] private float loopPause;

    

    // Start is called before the first frame update
    void Start()
    {
        if (looping)
        {
            //an infine looping aoe
            StartCoroutine(loopAOE());
        }
        else
        {
            //an repetion aoe
            StartCoroutine(repeatAOE());
        }
    }

    private void checkEnemyAOE()
    {
        print("checkEnemy called");

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach (Collider c in colliders)
        {
            //c is the enemy
            c.gameObject.GetComponent<enemyBase>().enemyHit(knockbackPower, healthDelta);
        }
    }

    IEnumerator loopAOE()
    {
        GameObject pO = Instantiate(particleObject, gameObject.transform);
        //particleObject.SetActive(true);
        checkEnemyAOE();
        yield return new WaitForSeconds(loopPause);
        //particleObject.SetActive(false);
        Destroy(pO);
        StartCoroutine(loopAOE());
    }
    IEnumerator repeatAOE()
    {
        print("Repeat AOE called");

        for (int i = 0; i < repetitions; i++)
        {
            GameObject pO = Instantiate(particleObject, gameObject.transform);
            checkEnemyAOE();
            yield return new WaitForSeconds(loopPause);
            //Destroy (pO);
        }
        Destroy(gameObject);
    }

}
