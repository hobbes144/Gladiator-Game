using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private Player_Equiped playerReference;

    [Header("Spawner Info")]
    [SerializeField] private int enemyCount;
    [SerializeField] public int maxSpawns;
    [SerializeField] public float spawnDelay = 4f;
    [SerializeField] public int roundIndividual;

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject enemyBasePrefab;
    [SerializeField] GameObject enemyTankPrefab;
    [SerializeField] GameObject enemyBerserkerPrefab;

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
            StartCoroutine(enemySpawn(maxSpawns, roundIndividual));
            enableSpawn = false;
        }
    }

    private IEnumerator enemySpawn(int maxSpawns, int roundNumber)
    {
        if (roundNumber == 10)
        {
            Debug.Log("It is round 10");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                int whatSpawn = Random.Range(0, 10);
                if (!playerReference.playerDead && whatSpawn >= 5)
                {
                    Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                }
                else if (whatSpawn >= 1)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 9)
        {
            Debug.Log("It is round 9");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                int whatSpawn = Random.Range(0, 10);
                if (!playerReference.playerDead && whatSpawn >= 6)
                {
                    Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                }
                else if (whatSpawn >= 2)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 8)
        {
            Debug.Log("It is round 8");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                int whatSpawn = Random.Range(0, 10);
                if (!playerReference.playerDead && whatSpawn >= 7)
                {
                    Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                }
                else if (whatSpawn >= 4)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 7)
        {
            Debug.Log("It is round 7");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                int whatSpawn = Random.Range(0, 10);
                if (!playerReference.playerDead && whatSpawn >= 8)
                {
                    Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                }
                else if (whatSpawn >= 5)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 6)
        {
            Debug.Log("It is round 6");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                int whatSpawn = Random.Range(0, 10);
                if (!playerReference.playerDead && whatSpawn == 9)
                {
                    Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                }
                else if (whatSpawn >= 6)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 5)
        {
            Debug.Log("It is round 5");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                int whatSpawn = Random.Range(0, 10);
                if (whatSpawn >= 7)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 4)
        {
            Debug.Log("It is round 4... Tank Round");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 3)
        {
            Debug.Log("It is round 3... Berserker Round");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }

        }
        else if (roundNumber == 2)
        {
            Debug.Log("It is round 2");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        }
        else if (roundNumber == 1)
        {
            Debug.Log("It is round 1");
            for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
            {
                if (!playerReference.playerDead)
                {
                    Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                }
                //Debug.Log("Enemy is spawned");
                yield return new WaitForSeconds(spawnDelay);

            }


        } else if (roundNumber == 0)
        {
            
            {
                Debug.Log("It is endless");
                for (enemyCount = 0; enemyCount >= 0; enemyCount++)
                {
                    int whatSpawn = Random.Range(0, 4);
                    if (!playerReference.playerDead && whatSpawn == 3)
                    {
                        Instantiate(enemyTankPrefab, transform.position, Quaternion.identity);
                    } else if (whatSpawn == 2)
                    {
                        Instantiate(enemyBerserkerPrefab, transform.position, Quaternion.identity);
                    } else
                    {
                        Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
                    }
                    //Debug.Log("Enemy is spawned");
                    yield return new WaitForSeconds(spawnDelay);

                }


            }
        }

    }
}
