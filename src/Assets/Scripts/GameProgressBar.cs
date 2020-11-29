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

    private ProcessorBar processor;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = progressBar.maxValue;
        playerValue = progressBar.value;
        playerSpeed = 1.5f;
        processor = GameObject.Find("ProcessorBar").GetComponent<ProcessorBar>();
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
            Debug.Log("Game Clear");
        }

        if (playerValue == processor.processorValue)  //Game End
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndGame();
            Debug.Log("Game End");
        }
    }
}
