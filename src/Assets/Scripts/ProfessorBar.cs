using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfessorBar : MonoBehaviour
{
    public Slider professorBar;

    float maxValue;
    public float professorValue = -1.0f;
    public float professorSpeed;
    public float professorTime;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = professorBar.maxValue;
        professorSpeed = 1.0f;  // round 3 = 1.3f
    }

    // Update is called once per frame
    void Update()
    {
        professorTime += Time.deltaTime;

        if (professorTime > 0.1f)
        {
            professorBar.value += professorSpeed;
            professorTime = 0f;
            professorValue = professorBar.value;
        }
    }

    public float GetProfessorValue()
    {
        return professorValue;
    }
}
