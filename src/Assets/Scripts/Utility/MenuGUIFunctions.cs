using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuGUIFunctions : MonoBehaviour
{
    //Sets the level to LVL1. Begins the game.
    public void StartGame()
    {
        SceneManager.LoadScene("Infinite");
    }

    //Quits game
    public void Exit()
    {
        Application.Quit();
    }
    
    public void OpenMainMenu()
    {
        Time.timeScale = 1;

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().setStagetoOne();
        Debug.Log("stage num : " + GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getStage());

        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadThisLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
