using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBox : MonoBehaviour
{
    [Header("Box Info")]
    [SerializeField] private float duration;
    [SerializeField] private float damage;
    [SerializeField] private float knockbackPower;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }

    public void updateDamage(float factor)
    {
        damage *= factor;
    }

    private void OnTriggerEnter(Collider other)
    {
        //other has entered the trigger, do damage (KNOCKBACK MAYBE)
        if(other.gameObject.GetComponent<enemyBase>() != null)
        {
            other.gameObject.GetComponent<enemyBase>().enemyHit(damage, knockbackPower);
        }
    }
}