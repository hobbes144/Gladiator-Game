using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Projectile Weapon")]
    [SerializeField] private Player_Equiped player;
    [SerializeField] private GameObject triggerBox;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool semiauto;

    [Header("Trigger Box Info")]
    [SerializeField] private float rechargeTime;
    private bool canFire = true;

    public void meleeFired()
    {
        if (canFire)
        {
            GameObject box = Instantiate(triggerBox, spawnPoint.position, Quaternion.identity);
            box.GetComponent<TriggerBoxScript>().updateDamage(player.rangedDamageFactor);

            canFire = false;
            StartCoroutine(resetBoolAfterDuration(canFire, rechargeTime));
        }
    }

    IEnumerator resetBoolAfterDuration(bool toReset, float duration)
    {
        yield return new WaitForSeconds(duration);
        toReset = true;
    }
}
