using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Melee Weapon")]
    private Player_Equiped player;
    [SerializeField] private GameObject triggerBox;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool semiauto;
    [SerializeField] private string animationTitle;

    [Header("Weapon Info")]
    [SerializeField] private float rechargeTime;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        
    }

    public void meleeFired()
    {
        if (audio != null)
        {
            audio.Play();
        }
        player = GameObject.FindWithTag("Player").GetComponent<Player_Equiped>();

        GameObject box = Instantiate(triggerBox, spawnPoint.position, Quaternion.identity);
        box.transform.position = spawnPoint.position;
        box.GetComponentInChildren<triggerBox>().updateDamage(player.rangedDamageFactor);

        gameObject.GetComponent<Animator>().Play(animationTitle);
    }

    public float getRechargeTime()
    {
        if (!semiauto) { return rechargeTime; }
        else { return 0.0f; }
    }

    IEnumerator resetBoolAfterDuration(bool toReset, float duration)
    {
        yield return new WaitForSeconds(duration);
        toReset = true;
    }
}
