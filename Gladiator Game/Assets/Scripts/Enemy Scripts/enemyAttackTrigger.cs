using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackTrigger : MonoBehaviour
{
    [Header("Box Info")]
    [SerializeField] private float duration;
    [SerializeField] private float damage;
    [SerializeField] private float knockbackPower;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject.transform.parent.gameObject, duration);
        Destroy(gameObject, 1);
    }



    public void setEffects(float newDamage, float newKnockbackPower)
    {
        damage = newDamage;
        knockbackPower = newKnockbackPower;
    }

    private void OnTriggerEnter(Collider other)
    {
        //other has entered the trigger, do damage (KNOCKBACK MAYBE)
        if (other.gameObject.GetComponent<Player_Equiped>() != null)
        {
            print("Player has been hit");
            other.gameObject.GetComponent<Player_Equiped>().playerDamaged(damage, knockbackPower);
        }
    }
}