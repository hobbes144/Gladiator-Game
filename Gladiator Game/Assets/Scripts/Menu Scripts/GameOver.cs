using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float currHealth;
    public GameObject GameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <=0)
        {
            GameOverCanvas.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit(); //How to get out of any program in Unity
    }
}
