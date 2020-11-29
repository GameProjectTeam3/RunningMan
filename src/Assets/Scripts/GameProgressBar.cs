using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressBar : MonoBehaviour
{
    public Slider progressBar;
    public Slider processorBar;

    public float playerValue;
    public float processorValue;
    public float maxValue;
    public float playerTime;
    public float processorTime;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = progressBar.maxValue;

        playerValue = progressBar.value;
        processorValue = processorBar.value;

        Debug.Log(maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        playerTime += Time.deltaTime;
        processorTime += Time.deltaTime;

        if (playerTime > 0.1f)
        {
            progressBar.value += 1.5f;
            playerTime = 0f;
            playerValue = progressBar.value;
        }

        if(processorTime > 0.05f)
        {
            processorBar.value += 1.0f;
            processorTime = 0f;
            processorValue = processorBar.value;
        }
    }
}
