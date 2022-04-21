using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyBasePrefab;
    [SerializeField] private int enemyCount;
    [SerializeField] private int maxSpawns;
    [SerializeField] private float spawnDelay;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawn(maxSpawns));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator enemySpawn(int maxSpawns)
    {
        
        for (enemyCount = 0; enemyCount < maxSpawns; enemyCount++)
        {
            Instantiate(enemyBasePrefab, transform.position, Quaternion.identity);
            //Debug.Log("Enemy is spawned");
            yield return new WaitForSeconds(spawnDelay);

        }

    }
}
