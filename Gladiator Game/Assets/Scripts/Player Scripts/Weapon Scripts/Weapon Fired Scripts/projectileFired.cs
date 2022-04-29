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

    private void Start()
    {
        Physics.IgnoreLayerCollision(3,6, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        //print("collided with: "+ collision.gameObject);

        //Projectile has collided with a target
        if (collision.gameObject.GetComponent<enemyBase>() != null) {
            collision.gameObject.GetComponent<enemyBase>().enemyHit(damage, knockbackPower);
        }

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
