using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public string firstLevel;
    public string optionsScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel); //Loads into First Scene
    }


    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsScene);
    }


    public void CloseOptions()
    {
        
    }


    public void QuitGame()
    {
        Application.Quit(); //How to get out of any program in Unity
    }

}
