using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour
{
    [Header("Box Info")]
    [SerializeField] private float duration;
    [SerializeField] private float damage;

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
        //other has entered the trigger, do damage
    }
}
