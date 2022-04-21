using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Projectile Weapon")]
    private Player_Equiped player;
    [SerializeField] private GameObject triggerBox;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool semiauto;

    [Header("Trigger Box Info")]
    [SerializeField] private float rechargeTime;

    private void Start()
    {
        
    }

    public void meleeFired()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player_Equiped>();

        GameObject box = Instantiate(triggerBox, spawnPoint.position, Quaternion.identity);
        box.transform.position = spawnPoint.position;
        box.GetComponentInChildren<triggerBox>().updateDamage(player.rangedDamageFactor);
    }

    public float getRechargeTime()
    {
        if (!semiauto) { return rechargeTime; }
        else { return 0.0f; }
    }

    IEnumerator resetBoolAfterDuration(bool toReset, float duration)
    {
        yield return new WaitForSeconds(duration);
        toReset = true;
    }
}
