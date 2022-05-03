using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControlReference : MonoBehaviour
{
    private spawnerController whatGamemode;
    private MainMenuScript menu;

    // Start is called before the first frame update
    void Start()
    {
        whatGamemode = GameObject.FindWithTag("spawnerControl").GetComponent<spawnerController>();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
