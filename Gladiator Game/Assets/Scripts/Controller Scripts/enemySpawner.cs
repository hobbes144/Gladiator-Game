using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyBasePrefab;

    [SerializeField] private float enemyInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyBasePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemyType)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemyType, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemyType));
    }
}
