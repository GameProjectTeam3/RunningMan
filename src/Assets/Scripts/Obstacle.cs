using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Uses a timestamp method to destroy the object after player zooms by it.
public class Obstacle : MonoBehaviour
{
    //Time until the obstacle is destroyed.
    public float deathTime = 5.0f;

    //Used to keep track of time since creation.
    private float initTime;

    //무작위로 선택할 텍스쳐 배열
    public Texture[] textures;

    // Start is called before the first frame update
    void Start()
    {
        //Time since level loaded.
        initTime = Time.timeSinceLevelLoad;

        int stage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getStage();
        int idx;

        if (stage == 1)
        {
            idx = Random.Range(0, 5);
        }
        else if (stage == 2)
        {
            idx = Random.Range(6, 13);
        }
        else
        {
            idx = Random.Range(14, 19);
        }

        //// 조건으로 0-5, 6-13, 14-19 주면 랜덤 텍스쳐링 가능
        //int idx = Random.Range(0, textures.Length);
        //차일드 게임오브젝트의 MeshRenderer 컴포넌트를 하나만 가져옴
        GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[idx];

        // 크기 2배로 늘리기
        transform.localScale = new Vector3(2, 2, 2);

        ///////CHEAT CODES///////////
        //Sets renderer materials to random INDP material if the cheat is activated
        if (GameObject.FindGameObjectWithTag("CheatCodeManager").GetComponent<CheatCodes>().indpSkinActive)
        {
            //Random int to choose what skin the obstacle has
            int rand = Random.Range(0, 8);

            //Set material to corresponding number.
            GetComponent<Renderer>().material = GameObject.FindGameObjectWithTag("CheatCodeManager").GetComponent<CheatCodes>().indpMat[rand];
        }
        ////////////////////////////
    }

    private void Update()
    {
        //If the object has been around lounger than deathtime destroy it.
        if (Time.timeSinceLevelLoad - initTime > deathTime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //If the block detects a collision from the player tag, end the game.
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetPlayerSpeed(true);
            GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<GameProgressBar>().SetProgressBarValue(true);
            StartCoroutine("timerCoroutine");

            Debug.Log("speed decreased" + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().movementSpeed);
        }
    }

    IEnumerator timerCoroutine()
    {
        yield return new WaitForSeconds(2.5f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetPlayerSpeed(false);
        GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<GameProgressBar>().SetProgressBarValue(false);
    }
}
