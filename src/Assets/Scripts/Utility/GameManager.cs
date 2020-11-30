using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Tracks score and other game data.
public class GameManager : MonoBehaviour
{
    //UI elements
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI scoreText;
    public GameObject endGamePanel;
    public GameObject problemPanel;
    public TextMeshProUGUI endGameScoreText;
    public TextMeshProUGUI problemText;
    public TMP_InputField answer_Input; // = GetComponent<TMP_InputField>();

    //Score variable.
    private float score;
    public static int stage = 1;

    //Game is over.
    private bool endGame;
    private static bool clearStage = false;

    // Update is called once per frame
    void Update()
    {
        //Increment score. +1 score a second.
        score += 1 * Time.deltaTime;

        //Cast the float to make reading the score easier.
        scoreText.text = "SCORE: " + (int)score;
        stageText.text = "STAGE: " + stage;

        //Reset spawn and map when distance gets too large.
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z < -10000)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0.5f, 0);
            GameObject.FindGameObjectWithTag("Map").transform.position = new Vector3(0, 0, 0);
        }

        //Allows the player to press space to restart.
        if (Input.GetKeyDown(KeyCode.Space) && endGame)
        {
            GameObject.Find("MenuGUIFunctions").GetComponent<MenuGUIFunctions>().ReloadThisLevel();
        }


        if ((int)score == 5)
        {
            clearStage = true;
            EndGame();
        }
    }

    private void Start()
    {
        //If they restart the game, it should set this to false.
        endGame = false;
        GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Obstacle>().setCollisionNumZero();
        Debug.Log("collision number " + GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Obstacle>().getCollisionNum());
        if (clearStage)
        {
            stage++;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().movementSpeed *= stage;
            clearStage = false;
        }
        //Debug.Log("player speed " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().movementSpeed);

    }

    //Ran from OnTriggerEnter() from any obstacle colliding with the Player.
    public void EndGame()
    {
        //Turn on the UI and remove the scoretext in the top left corner.
        endGamePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        stageText.gameObject.SetActive(false);
        endGameScoreText.text = "FINAL SCORE: " + (int)score;


        //Stops player movement but allows GUI and key input.
        Time.timeScale = 0;

        //Allows after game input checking.
        endGame = true;
    }

    public int getStage()
    {
        return stage;
    }

    public void setStagetoOne()
    {
        stage = 1;
        clearStage = false;
    }
}
