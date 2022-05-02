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
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject dagger;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject crossBow;
    [SerializeField] private GameObject bow;
    [SerializeField] private GameObject greekFire;

    [Header("Screens")] // Accesss Screens
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private HealthBar healthBar;

    //Weapon variables (for swapping)
    private Weapon_Equip weaponEquiped; //Enum representation of weapon
    private GameObject weapon; //Weapon player is using
    private GameObject wepPrefab;//Prefab of weapon to create

    //for movement purposes
    private FirstPersonMovement firstPersonMovement; //used for speed management

    //attacking varibales
    private bool canFire = true;
    private float dur = 0;
    private Animator handAnimator = null;

    //is the player dead
    public bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonMovement = gameObject.GetComponent<FirstPersonMovement>();

        GameObject firstDagger = Instantiate(dagger, hand.transform);
        weaponEquiped = Weapon_Equip.Dagger;
        weapon = firstDagger;
        weapon.transform.parent = hand.transform;

        GameOverCanvas.SetActive(false);
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
        bool swapped = false;
        //swap weapon left
        if (Input.GetKeyDown(KeyCode.Q))
        {
            swapped = true;
            switch (weaponEquiped)
            {
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
            swapped = true;
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

        if (swapped) { 
            switch (weaponEquiped) {
                case Weapon_Equip.Dagger:
                    wepPrefab = dagger;
                    break;
                case Weapon_Equip.Sword:
                    wepPrefab = sword;
                    break;
                case Weapon_Equip.Crossbow:
                    wepPrefab = crossBow;
                    break;
                case Weapon_Equip.Bow:
                    wepPrefab = bow;
                    break;
                case Weapon_Equip.GreekFire:
                    wepPrefab = greekFire;
                    break;
            }
    
            while (hand.gameObject.transform.childCount > 0)
            {
                GameObject removed = hand.gameObject.transform.GetChild(0).gameObject;
                removed.transform.parent = null;
                Destroy(removed);
            }

            weapon = Instantiate(wepPrefab, hand.transform);
            weapon.transform.parent = hand.transform;
        }
    }
    private void handleAttack()
    {
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            ProjectileWeapon projectileWeapon = weapon.GetComponent<ProjectileWeapon>();
            if (projectileWeapon != null)
            {
                projectileWeapon.projectileFired();
                dur = projectileWeapon.getRechangeTime();
            }
            MeleeWeapon meleeWeapon = weapon.GetComponent<MeleeWeapon>();
            if (meleeWeapon != null)
            {
                meleeWeapon.meleeFired();
                dur = meleeWeapon.getRechargeTime();
            }

            canFire = false;
            StartCoroutine(resetCanFire());

            print("Dur = " + dur);
        }
    }

    private void playerDeath()
    {
        GameOverCanvas.SetActive(true);
        playerDead = true;
    }

    //----------------------PUBLIC FUNCTIONS----------------------
    //-----------Health / Armor Functions-----------
    public void changeMaxHealth(float delta)
    {
        maxHealth += delta;

        healthBar.setMaxHealth(maxHealth);
    }
    public void changeCurrHealth(float delta)
    {
        currHealth += delta;

        healthBar.setHealth(currHealth);
    }
    public void changeArmor(float delta)
    {
        armor += delta;
    }
    public void playerDamaged(float damage)
    {
        currHealth -= damage * ((100.0f - armor) / 100.0f);

        healthBar.setHealth(currHealth);

        if (currHealth <= 0)
        {
            playerDeath();
            //player dies
            print("GAME OVER - PLAYER DEATH");
        }
    }
    public void healPlayer(float amount)
    {
        currHealth += amount;
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
        healthBar.setHealth(currHealth);
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

    public void pickedUp(float healthBoost, float speedBoost, float armorBoost, float meleeBoost, float rangedBoost)
    {
        StartCoroutine(pickedUpCo(healthBoost, speedBoost, armorBoost, meleeBoost, rangedBoost));
    }


    //-----------Corountines-----------
    IEnumerator resetCanFire()
    {
        yield return new WaitForSeconds(dur);
        canFire = true;
    }

    IEnumerator pickedUpCo(float healthBoost, float speedBoost, float armorBoost, float meleeBoost, float rangedBoost)
    {
        print("Picked Up Coroutine Called");
        healPlayer(healthBoost);
        changeSpeed(speedBoost);
        changeArmor(armorBoost);
        changeMeleeDamageFactor(meleeBoost);
        changeRangedDamageFactor(rangedBoost);

        //ITEM PICK UP CODE GOES HERE

        yield return new WaitForSeconds(10);

        changeSpeed(-1 * speedBoost);
        changeArmor(-1 * armorBoost);
        changeMeleeDamageFactor(-1 * meleeBoost);
        changeRangedDamageFactor(-1 * rangedBoost);
    }
}
