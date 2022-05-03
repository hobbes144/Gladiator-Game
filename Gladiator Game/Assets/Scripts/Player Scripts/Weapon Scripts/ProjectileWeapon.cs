using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [Header("Projectile Weapon")]
    private Player_Equiped player;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private bool semiauto;

    [Header("Fire Info")]
    [SerializeField] private float rechargeTime;
    [SerializeField] private float power;
    [SerializeField] private AudioSource audio;

    public void projectileFired()
    {
        if (audio != null)
        {
            audio.Play();
        }

        player = GameObject.FindWithTag("Player").GetComponent<Player_Equiped>();

        GameObject proj = Instantiate(projectile, launchPoint.localPosition, launchPoint.rotation);
        proj.transform.position = launchPoint.position;
        proj.GetComponent<projectileFired>().updateDamage(player.rangedDamageFactor);
        proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * power, ForceMode.Impulse);
    }

    public float getRechangeTime()
    {
        if (!semiauto) { return rechargeTime; }
        else { return 0.0f; }
        
    }
}
