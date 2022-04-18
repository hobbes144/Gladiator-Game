using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    // public GameObject pauseMenu;

    [SerializeField] private bool isPaused = false;
    // public bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
        DeactivateMenu();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // isPaused = !isPaused;
            if (!isPaused)
            {
                ActivateMenu();
            }
            else 
            {
                DeactivateMenu();
            }
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0; // This will pause the actual game
        // AudioListener.pause = true;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    
    public void DeactivateMenu()
    {
        Time.timeScale = 1; // This will resume the game to its normal runtime
        // AudioListener.pause = false;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}
