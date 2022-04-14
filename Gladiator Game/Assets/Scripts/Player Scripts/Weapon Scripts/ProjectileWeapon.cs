using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [Header("Projectile Weapon")]
    [SerializeField] private Player_Equiped player;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private bool semiauto;

    [Header("Fire Info")]
    [SerializeField] private float rechargeTime;
    [SerializeField] private float power;
    private bool canFire = true;

    public void projectileFired()
    {
        if (semiauto? true : canFire)
        {
            GameObject proj = Instantiate(projectile, launchPoint.position, Quaternion.identity);
            proj.GetComponent<ProjectileScript>().updateDamage(player.rangedDamageFactor);
            proj.GetComponent<Rigidbody>().AddForce(launchPoint.forward * power, ForceMode.Impulse);

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
