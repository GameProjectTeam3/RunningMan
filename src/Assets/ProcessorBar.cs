using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessorBar : MonoBehaviour
{
    public Slider processorBar;

    float maxValue;
    public float processorValue;
    public float processorSpeed;
    public float processorTime;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = processorBar.maxValue;
        processorValue = -1.0f;
        processorSpeed = 1.0f;  // round 3 = 1.3f
    }

    // Update is called once per frame
    void Update()
    {

        processorTime += Time.deltaTime;

        if (processorTime > 0.1f)
        {
            processorBar.value += processorSpeed;
            processorTime = 0f;
            processorValue = processorBar.value;
        }
    }
}
