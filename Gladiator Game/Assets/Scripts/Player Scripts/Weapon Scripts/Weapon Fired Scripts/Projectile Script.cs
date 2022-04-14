using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [Header("Projectile Info")]
    [SerializeField] private float damage;
    //[SerializeField] private aoeEffect aoeEffect;

    private void OnCollisionEnter(Collision collision)
    {
        //Projectile has collided with a target
    }

    public void updateDamage(float factor)
    {
        damage *= factor;
    }
}
