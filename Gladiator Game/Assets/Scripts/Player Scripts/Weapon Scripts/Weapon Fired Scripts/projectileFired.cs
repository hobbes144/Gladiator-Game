using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFired : MonoBehaviour
{
    [Header("Projectile Info")]
    [SerializeField] private float damage;
    [SerializeField] private float knockbackPower;

    [Header("Hit Effect")]
    [SerializeField] private GameObject hitEffect;
    //[SerializeField] private aoeEffect aoeEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        //Projectile has collided with a target

        if (hitEffect != null)
        {
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
        }
    }

    public void updateDamage(float factor)
    {
        damage *= factor;
    }
}
