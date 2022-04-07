using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [Header("Projectile Weapon")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float rechargeTime;

    public void projectileFired()
    {

    }
}
