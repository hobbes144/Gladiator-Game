using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{

    private enemySpawner northReference;
    private enemySpawner eastReference;
    private enemySpawner southReference;
    private enemySpawner westReference;

    [SerializeField] private GameObject northSpawn;
    [SerializeField] private GameObject eastSpawn;
    [SerializeField] private GameObject southSpawn;
    [SerializeField] private GameObject westSpawn;

    [SerializeField] private int spawnPoints;
    [SerializeField] private int round;

    // Start is called before the first frame update
    void Start()
    {
        northReference = northSpawn.GetComponent<enemySpawner>();
        eastReference = eastSpawn.GetComponent<enemySpawner>();
        southReference = southSpawn.GetComponent<enemySpawner>();
        westReference = westSpawn.GetComponent<enemySpawner>();

        roundSpawn(spawnPoints, round);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void roundSpawn(int roundPoints, int round)
    {


        spawnNorth(roundPoints, round);
        spawnEast(roundPoints, round);
        spawnSouth(roundPoints, round);
        spawnWest(roundPoints, round);

    }

    private void spawnNorth(int northPoints, int round)
    {
        northReference.roundNumber = round;
        northReference.maxSpawns = northPoints;
        northReference.enableSpawn = true;
    }

    private void spawnEast(int eastPoints, int round)
    {
        eastReference.roundNumber = round;
        eastReference.maxSpawns = eastPoints;
        eastReference.enableSpawn = true;
    }

    private void spawnSouth(int southPoints, int round)
    {
        southReference.roundNumber = round;
        southReference.maxSpawns = southPoints;
        southReference.enableSpawn = true;
    }

    private void spawnWest(int westPoints, int round)
    {
        westReference.roundNumber = round;
        westReference.maxSpawns = westPoints;
        westReference.enableSpawn = true;
    }

}
