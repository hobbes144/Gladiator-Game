using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Item : MonoBehaviour
{
    [Header("Power Up Stats")]
    [SerializeField] private float healthBoost;
    [SerializeField] private float speedBoost;
    [SerializeField] private float armorBoost;
    [SerializeField] private float meleeBoost;
    [SerializeField] private float rangedBoost;

    [Header("Pick Up Item Count")]
    [SerializeField] private float boltCount;
    [SerializeField] private float arrowCount;
    [SerializeField] private float greekFireCount;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Items");
        Physics.IgnoreLayerCollision(7, 8);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player_Equiped pEquiped = other.GetComponent<Player_Equiped>();
        pEquiped.pickedUp(healthBoost, speedBoost, armorBoost, meleeBoost, rangedBoost);
        Destroy(gameObject);
    }

}
