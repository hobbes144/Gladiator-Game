using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public string firstLevel;

    // public string optionsScene;

    public GameObject MainMenuButtons;
    public GameObject GamePlayScreen;
    public GameObject SelectGameMode;
    public GameObject ParticleSystemFireRing;


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
        ParticleSystemFireRing.SetActive(true);
    }


    public void SelectMode()
    {
        SelectGameMode.SetActive(true);
        MainMenuButtons.SetActive(false);
        ParticleSystemFireRing.SetActive(false);
    }

    public void closeSelectMode()
    {
        SelectGameMode.SetActive(false);
        MainMenuButtons.SetActive(true);
        ParticleSystemFireRing.SetActive(true);
    }


    public void StartStages() // To select stages game mode
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void StartEndless() // To select endless game mode
    {
        SceneManager.LoadScene(firstLevel);
    }



    public void HowToPlay()
    {
        GamePlayScreen.SetActive(true); //Shows GamePlayScreen
        ParticleSystemFireRing.SetActive(false);
        MainMenuButtons.SetActive(false);
    }


    public void CloseOptions()
    {
        GamePlayScreen.SetActive(false); //Hides GamePlayScreen
        ParticleSystemFireRing.SetActive(true);
        MainMenuButtons.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit(); //How to get out of any program in Unity
    }



}
