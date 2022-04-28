using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private Player_Equiped playerReference;

    [SerializeField] GameObject enemyBasePrefab;
    [SerializeField] GameObject enemyVariantPrefab;
    [SerializeField] GameObject enemyRedPrefab;
    [SerializeField] private int enemyCount;
    [SerializeField] public int maxSpawns;
    [SerializeField] private float spawnDelay;
    [SerializeField] public int roundNumber;

    public bool enableSpawn;



    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindWithTag("Player").GetComponent<Player_Equiped>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSpawn)
        {
            StartCoroutine(enemySpawn(maxSpawns, roundNumber));
            enableSpawn = false;
        }
    }

    private IEnumerator enemySpawn(int maxSpawns, int roundNumber)
    {
        if (roundNumber == 10)
        {
            Debug.Log("It is round 10");



        }
        else if (roundNumber == 9)
        {
            Debug.Log("It is round 9");



        }
        else if (roundNumber == 8)
        {
            Debug.Log("It is round 8");



        }
        else if (roundNumber == 7)
        {
            Debug.Log("It is round 7");



        }
        else if (roundNumber == 6)
        {
            Debug.Log("It is round 6");



        }
        else if (roundNumber == 5)
        {
            Debug.Log("It is round 5");



        }
        else if (roundNumber == 4)
        {
            Debug.Log("It is round 4");



        }
        else if (roundNumber == 3)
        {
            Debug.Log("It is round 3");
            for (enemyCount = 0; enemyCount < 15; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    int whichEnemy = Random.Range(1, 4);
                    if (whichEnemy == 1)
                    {
                        Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                    }
                    else if (whichEnemy == 2)
                    {
                        Instantiate(enemyVariantPrefab, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemyRedPrefab, transform.position, Quaternion.identity);
                    }
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);
            }

        }
        else if (roundNumber == 2)
        {
            Debug.Log("It is round 2");
            for (enemyCount = 0; enemyCount < 15; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    int whichEnemy = Random.Range(1, 3);
                    if (whichEnemy == 1)
                    {
                        Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(enemyVariantPrefab, transform.position, Quaternion.identity);
                    }
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else 
        {
            Debug.Log("It is round 1");
            for (enemyCount = 0; enemyCount < 10; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }

        }

    }
}
