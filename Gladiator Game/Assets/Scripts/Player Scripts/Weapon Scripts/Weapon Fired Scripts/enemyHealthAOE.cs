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
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        foreach (Collider c in colliders)
        {
            //c is the enemy
            c.gameObject.GetComponent<enemyBase>().enemyHit(healthDelta, knockbackPower);
        }
    }

    IEnumerator loopAOE()
    {
        particleObject.SetActive(true);
        checkEnemyAOE();
        yield return new WaitForSeconds(loopPause);
        particleObject.SetActive(false);
        StartCoroutine(loopAOE());
    }
    IEnumerator repeatAOE()
    {
        for (int i = 0; i < repetitions; i++)
        {
            particleObject.SetActive(true);
            checkEnemyAOE();
            yield return new WaitForSeconds(loopPause);
            particleObject.SetActive(false);
        }
    }

}
