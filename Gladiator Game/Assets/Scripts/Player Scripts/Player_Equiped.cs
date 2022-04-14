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
    [SerializeField] private float maxHealth = 100; //maximum health
    [SerializeField] private float currHealth = 100; //current health
    [SerializeField] public float meleeDamageFactor = 1; //melee multiplier
    [SerializeField] public float rangedDamageFactor = 1; //ranged multiplier
    [SerializeField] private float armor = 0; //% of reduced damage

    [Header("Weapons")] //Serialized Weapon Game Objects
    [SerializeField] private GameObject dagger;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject crossBow;
    [SerializeField] private GameObject bow;
    [SerializeField] private GameObject greekFire;

    private Weapon_Equip weaponEquiped; //Enum representation of weapon
    private GameObject weapon; //Weapon player is using

    private FirstPersonMovement firstPersonMovement; //used for speed management

    // Start is called before the first frame update
    void Start()
    {
        firstPersonMovement = gameObject.GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        handleWeaponSwap();
        handleAttack();
    }

    //----------------------PRIVATE FUNCTIONS----------------------
    //-----------Weapon Management-----------
    private void handleWeaponSwap()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (weaponEquiped)
            {
                //swap weapon left
                case Weapon_Equip.Dagger:
                    weaponEquiped = Weapon_Equip.GreekFire;
                    break;
                case Weapon_Equip.Sword:
                    weaponEquiped = Weapon_Equip.Dagger;
                    break;
                case Weapon_Equip.Crossbow:
                    weaponEquiped = Weapon_Equip.Sword;
                    break;
                case Weapon_Equip.Bow:
                    weaponEquiped = Weapon_Equip.Crossbow;
                    break;
                case Weapon_Equip.GreekFire:
                    weaponEquiped = Weapon_Equip.Bow;
                    break;
            }//end switch
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //swap weapons right
            switch (weaponEquiped)
            {
                case Weapon_Equip.Dagger:
                    weaponEquiped = Weapon_Equip.Sword;
                    break;
                case Weapon_Equip.Sword:
                    weaponEquiped = Weapon_Equip.Crossbow;
                    break;
                case Weapon_Equip.Crossbow:
                    weaponEquiped = Weapon_Equip.Bow;
                    break;
                case Weapon_Equip.Bow:
                    weaponEquiped = Weapon_Equip.GreekFire;
                    break;
                case Weapon_Equip.GreekFire:
                    weaponEquiped = Weapon_Equip.Dagger;
                    break;
            }//end switch
        }

        switch (weaponEquiped) {
            case Weapon_Equip.Dagger:
                weapon = dagger;
                break;
            case Weapon_Equip.Sword:
                weapon = sword;
                break;
            case Weapon_Equip.Crossbow:
                weapon = crossBow;
                break;
            case Weapon_Equip.Bow:
                weapon = bow;
                break;
            case Weapon_Equip.GreekFire:
                weapon = greekFire;
                break;
        }

    }
    private void handleAttack()
    {
        if (Input.GetButtonDown("Fire1")) {
            ProjectileWeapon projectileWeapon = weapon.GetComponent<ProjectileWeapon>();
            if (projectileWeapon != null)
            {
                projectileWeapon.projectileFired();
                return;
            }
            MeleeWeapon meleeWeapon = weapon.GetComponent<MeleeWeapon>();
            if (meleeWeapon != null)
            {
                meleeWeapon.meleeFired();
            }
        }
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
