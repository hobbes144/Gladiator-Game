using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    // public GameObject pauseMenu;

    [SerializeField] private bool isPaused = false;
    // public bool isPaused;

    public string mainMenu;
    // public GameObject pauseMenu;

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
        AudioListener.pause = true; // Pauses Audio
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    
    public void DeactivateMenu()
    {
        Time.timeScale = 1; // This will resume the game to its normal runtime
        AudioListener.pause = false; // Pauses Audio
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void MainMenuButton() //Sets Main Menu Button on Pause Screen
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void ResumePlay()
    {
        pauseMenu.SetActive(false);
    }
}
