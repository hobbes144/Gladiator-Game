using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public string firstLevel;
    public string endlessLevel;

    // public string optionsScene;

    public GameObject MainMenuButtons;
    public GameObject GamePlayScreen;
    public GameObject SelectGameMode;


    // Start is called before the first frame update
    void Start()
    {
        
        

        GamePlayScreen.SetActive(false);
        SelectGameMode.SetActive(false);
        MainMenuButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SelectMode()
    {
        SelectGameMode.SetActive(true);
        MainMenuButtons.SetActive(false);
    }

    public void closeSelectMode()
    {
        SelectGameMode.SetActive(false);
        MainMenuButtons.SetActive(true);
    }


    public void StartStages() // To select stages game mode
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void StartEndless() // To select endless game mode
    {
        SceneManager.LoadScene(endlessLevel);
    }



    public void HowToPlay()
    {
        GamePlayScreen.SetActive(true); //Shows GamePlayScreen
        MainMenuButtons.SetActive(false);
    }


    public void CloseOptions()
    {
        GamePlayScreen.SetActive(false); //Hides GamePlayScreen
        MainMenuButtons.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit(); //How to get out of any program in Unity
    }



}
