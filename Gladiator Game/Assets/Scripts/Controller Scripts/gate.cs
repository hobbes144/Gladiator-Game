using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    private spawnerController spawnController;
    [SerializeField] private GameObject spawnControllerObject;

    [Header("Gate Info")]
    private Player_Equiped player;
    [SerializeField] private Transform transport;
    [Header("Buffs")]
    [SerializeField] private float healthBuff;
    [SerializeField] private float speedBuff;
    [SerializeField] private float meleeBuff;
    [SerializeField] private float rangedBuff;

    public bool activeGate = false;

    void Start()
    {
        spawnController = spawnControllerObject.GetComponent<spawnerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activeGate)
        {
            player = other.GetComponent<Player_Equiped>();
            if (player != null)
            {
                player.changeMaxHealth(healthBuff);
                player.changeSpeed(speedBuff);
                player.changeMeleeDamageFactor(meleeBuff);
                player.changeRangedDamageFactor(rangedBuff);

                spawnController.roundSpawn(spawnController.roundNumber);

                player.gameObject.transform.position = transport.position;
            }
        }
    }

    public void setActiveGate(bool b)
    {
        activeGate = b;
    }
}
