using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RaceTimer : MonoBehaviour
{
    public float time;
    public bool timerOn = false;
    public Text timerText;
    public TMP_Text scoreText;
    public GameObject scoreboard;

    private PlayerLapper playerLapper;

    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        scoreboard.SetActive(false);
        timerOn = true;
        timerText.fontSize = 16;

        playerLapper = transform.parent.GetComponent<PlayerLapper>();

        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn && !(playerLapper.lap == 4 && playerLapper.checkpointIndex == 0))
        {
            time += Time.deltaTime;
            UpdateTimer(time);
        }
        else
        {
            Debug.Log(time);
            Debug.Log("Race is Finished");
            GameIsDone();
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format(" {0:00}  :  {1:00}\n Lap {2}/3\n Checkpoint {3}/{4}", minutes, seconds, playerLapper.lap, playerLapper.checkpointIndex + 1, CheckpointScript.checkpointNumber);
        scoreText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
    }

    public void GameIsDone()
    {
        scoreboard.SetActive(true);
        playerLapper.checkpointIndex = 0;
        playerLapper.lap = 1;
        Time.timeScale = 0;
        GameManager.isPlayable = false;
    }

    public void MainMenu()
    {
        playerLapper.checkpointIndex = 0;
        playerLapper.lap = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
