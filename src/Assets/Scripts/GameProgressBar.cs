using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressBar : MonoBehaviour
{
    public Slider progressBar;

    public float playerValue;
    public float maxValue;
    public float playerTime;
    public float playerSpeed;

    public bool isStageClear;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = progressBar.maxValue;
        playerValue = progressBar.value;
        playerSpeed = 3.0f;
        isStageClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerTime += Time.deltaTime;

        if (playerTime > 0.1f)
        {
            progressBar.value += playerSpeed;
            playerTime = 0f;
            playerValue = progressBar.value;
        }

        if (playerValue == maxValue) // Game Clear
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ClearGame();
            Debug.Log("player value = " + playerValue);
            isStageClear = true;
        }

        if (playerValue == GameObject.FindGameObjectWithTag("ProfessorBar").GetComponent<ProfessorBar>().professorValue)  // Game End
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndGame();
            Debug.Log("player value = " + playerValue + "professor value = " + GameObject.FindGameObjectWithTag("ProfessorBar").GetComponent<ProfessorBar>().professorValue);
        }
    }

    public void ResetProgressBar(float professorSpeed)
    {
        progressBar.value = 0f;
        playerValue = progressBar.value;
        GameObject.FindGameObjectWithTag("ProfessorBar").GetComponent<ProfessorBar>().ResetProfessorBar(professorSpeed);
    }

    public void SetProgressBarValue(bool isSlowPlayer)
    {
        if (isSlowPlayer)
        {
            playerSpeed = 1.5f;
        }
        else
        {
            playerSpeed = 3.0f;
        }
    }
}
