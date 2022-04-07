using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapon_Equip {Dagger, Sword, Crossbow, Bow, GreekFire};

public class Player_Equiped : MonoBehaviour
{

    /*
     * 
     * List of Public Functions to Call
     *  - changeMaxHealth 
     *  - changeCurrHealth
     *  - changeArmor
     *  - playerDamaged
     *  - playerHeal
     *  
     *  - changeSpeed
     *  
     *  - changeMeleeDamageFactor
     *  - changeRangeDamageFactor
     * 
     */

    [Header("Player Stats")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currHealth = 100;
    [SerializeField] private float meleeDamageFactor = 1;
    [SerializeField] private float rangedDamageFactor = 1;
    [SerializeField] private float armor = 0;

    private FirstPersonMovement firstPersonMovement;

    private Weapon_Equip weapon;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonMovement = gameObject.GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //----------------------PRIVATE FUNCTIONS----------------------
    //-----------Weapon Management-----------
    private void handleWeaponSwap()
    {

    }
    private void handleAttack()
    {

    }

    //----------------------PUBLIC FUNCTIONS----------------------
    //-----------Health / Armor Functions-----------
    public void changeMaxHealth(float delta)
    {
        maxHealth += delta;
    }
    public void changeCurrHealth(float delta)
    {
        currHealth += delta;
    }
    public void changeArmor(float delta)
    {
        armor += delta;
    }
    public void playerDamaged(float damage)
    {
        currHealth -= damage * ((100.0f - armor) / 100.0f);
    }
    public void healPlayer(float amount)
    {
        currHealth += amount;
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }
    //-----------Speed Functions-----------
    public void changeSpeed(float delta)
    {
        firstPersonMovement.buffSpeed(delta);
    }
    //-----------Factor Buffs-----------
    public void changeMeleeDamageFactor(float delta)
    {
        meleeDamageFactor += delta;
    }
    public void changeRangedDamageFactor(float delta)
    {
        rangedDamageFactor += delta;
    }


    //-----------Corountines-----------
    IEnumerator resetBoolAfterDuration(bool toReset, float duration)
    {
        yield return new WaitForSeconds(duration);
        toReset = true;
    }
}
