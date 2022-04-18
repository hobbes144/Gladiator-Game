using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public string firstLevel;

    // public string optionsScene;

    public GameObject GamePlayScreen;


    // Start is called before the first frame update
    void Start()
    {
        GamePlayScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel); //Loads into First Scene
    }


    public void HowToPlay()
    {
        GamePlayScreen.SetActive(true); //Shows GamePlayScreen
    }


    public void CloseOptions()
    {
        GamePlayScreen.SetActive(false); //Hides GamePlayScreen
    }


    public void QuitGame()
    {
        Application.Quit(); //How to get out of any program in Unity
    }



}
