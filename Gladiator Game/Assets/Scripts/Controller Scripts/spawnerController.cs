using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{

    private enemySpawner northReference;
    private enemySpawner eastReference;
    private enemySpawner southReference;
    private enemySpawner westReference;
    //private gate gate;

    [SerializeField] private GameObject northSpawn;
    [SerializeField] private GameObject eastSpawn;
    [SerializeField] private GameObject southSpawn;
    [SerializeField] private GameObject westSpawn;
    [SerializeField] private GameObject gateObject;

    [SerializeField] public int enemyDeadCount;
    [SerializeField] public int roundNumber;
    [SerializeField] public int enemyToSpawn;
    [SerializeField] public int enemiesToDie;

    [SerializeField] public bool endless = false;

    // Start is called before the first frame update
    void Start()
    {
        northReference = northSpawn.GetComponent<enemySpawner>();
        eastReference = eastSpawn.GetComponent<enemySpawner>();
        southReference = southSpawn.GetComponent<enemySpawner>();
        westReference = westSpawn.GetComponent<enemySpawner>();

        if (!endless) {
            roundSpawn(1);
        }
        else
        {
            endlessMode();
        }
    }

    // Update is called once per frameddd
    void Update()
    {
        if (enemiesToDie <= enemyDeadCount)
        {
            GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate");
            foreach (GameObject gate in gates)
            {
                gate.GetComponent<gate>().setActiveGate(true);
            }
        }
    }

    public void endlessMode()
    {
        enemyDeadCount = 0;

        spawnNorth(0, true);
        spawnEast(0, true);
        spawnSouth(0, true);
        spawnWest(0, true);
    }

    public void roundSpawn(int whichRound)
    {
        enemyDeadCount = 0;
        assignSpawnAmount(whichRound);
        enemiesToDie = 4 * enemyToSpawn;

        spawnNorth(whichRound, false);
        spawnEast(whichRound, false);
        spawnSouth(whichRound, false);
        spawnWest(whichRound, false);
        roundNumber += 1;

        GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate");
        foreach (GameObject gate in gates)
        {
            gate.GetComponent<gate>().setActiveGate(false);
        }

    }

    private void spawnNorth(int round, bool endless)
    {
        if (endless)
        {
            northReference.roundIndividual = 0;
        }
        else
        {
            northReference.roundIndividual = round;
            northReference.maxSpawns = enemyToSpawn;
        }
        northReference.enableSpawn = true;

    }

    private void spawnEast(int round, bool endless)
    {
        if (endless)
        {
            eastReference.roundIndividual = 0;
        }
        else
        {
            eastReference.roundIndividual = round;
            eastReference.maxSpawns = enemyToSpawn;
        }
        eastReference.enableSpawn = true;

    }

    private void spawnSouth(int round, bool endless)
    {
        if (endless)
        {
            southReference.roundIndividual = 0;
        }
        else
        {
            southReference.roundIndividual = round;
            southReference.maxSpawns = enemyToSpawn;
        }
        southReference.enableSpawn = true;

    }

    private void spawnWest(int round, bool endless)
    {
        if (endless)
        {
            westReference.roundIndividual = 0;
        }
        else
        {
            westReference.roundIndividual = round;
            westReference.maxSpawns = enemyToSpawn;
        }
        westReference.enableSpawn = true;

    }
    private void assignSpawnAmount(int round)
    {
        if (roundNumber > 10)
        {
            Debug.Log("Beaten the Game");
            enemyToSpawn = 0;
        }
        else if (roundNumber == 10)
        {
            Debug.Log("It is round 10");
            //for Trey's boss just set enemyToSpawn = 0 , and call boss spawn function
            enemyToSpawn = 30;
        }
        else if (roundNumber == 9)
        {
            Debug.Log("It is round 9");
            enemyToSpawn = 25;
        }
        else if (roundNumber == 8)
        {
            Debug.Log("It is round 8");
            enemyToSpawn = 20;
        }
        else if (roundNumber == 7)
        {
            Debug.Log("It is round 7");
            enemyToSpawn = 15;
        }
        else if (roundNumber == 6)
        {
            Debug.Log("It is round 6");
            enemyToSpawn = 10;
        }
        else if (roundNumber == 5)
        {
            Debug.Log("It is round 5");
            enemyToSpawn = 5;
        }
        else if (roundNumber == 4)
        {
            Debug.Log("It is round 4");
            enemyToSpawn = 2;
        }
        else if (roundNumber == 3)
        {
            Debug.Log("It is round 3");
            enemyToSpawn = 3;
        }
        else if (roundNumber == 2)
        {
            Debug.Log("It is round 2");
            enemyToSpawn = 5;
        }
        else
        {
            Debug.Log("It is round 1");
            enemyToSpawn = 3;
        }
    }

}
