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
        if (pEquiped != null)
        {
            StartCoroutine(pickedUp(pEquiped));
            Destroy(gameObject);
        }
    }

    IEnumerator pickedUp(Player_Equiped player)
    {
        player.healPlayer(healthBoost);
        player.changeSpeed(speedBoost);
        player.changeArmor(armorBoost);
        player.changeMeleeDamageFactor(meleeBoost);
        player.changeRangedDamageFactor(rangedBoost);

        //ITEM PICK UP CODE GOES HERE

        yield return new WaitForSeconds(10);

        player.changeSpeed(-1 * speedBoost);
        player.changeArmor(-1 * armorBoost);
        player.changeMeleeDamageFactor(-1 * meleeBoost);
        player.changeRangedDamageFactor(-1 * rangedBoost);
    }
}
