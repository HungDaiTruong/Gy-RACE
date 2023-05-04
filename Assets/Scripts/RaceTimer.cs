using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;
using TMPro;
=======
>>>>>>> Stashed changes

public class RaceTimer : MonoBehaviour
{
    public float time;
    public bool timerOn = false;
    public Text timerText;
<<<<<<< Updated upstream
    public TMP_Text scoreText;
    public GameObject scoreboard;

    private PlayerLapper playerLapper;

    private GameObject player1;
    private GameObject player2;
=======
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        scoreboard.SetActive(false);
        timerOn = true;
        timerText.fontSize = 16;

        playerLapper = transform.parent.GetComponent<PlayerLapper>();

        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
=======
        timerOn = true;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        // Ends when the 4th lap is starting, for a total of 3 laps
        if(timerOn && !(playerLapper.lap == 4 && playerLapper.checkpointIndex == 0))
=======
        if(timerOn && !(CheckpointScript.lap == 3 && CheckpointScript.count == 1))
>>>>>>> Stashed changes
        {
            time += Time.deltaTime;
            UpdateTimer(time);
        }
        else
        {
            Debug.Log(time);
            Debug.Log("Race is Finished");
<<<<<<< Updated upstream
=======
            time = 0;
>>>>>>> Stashed changes
            GameIsDone();
        }
    }

    void UpdateTimer(float currentTime)
    {
<<<<<<< Updated upstream
        // Updates the timer and displays the time, laps and checkpoints counts
=======
>>>>>>> Stashed changes
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

<<<<<<< Updated upstream
        timerText.text = string.Format(" {0:00}  :  {1:00}\n Lap {2}/3\n Checkpoint {3}/{4}", minutes, seconds, playerLapper.lap, playerLapper.checkpointIndex + 1, CheckpointScript.checkpointNumber);
        // Value used as a display during the scoreboard
        scoreText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
=======
        timerText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
>>>>>>> Stashed changes
    }

    public void GameIsDone()
    {
<<<<<<< Updated upstream
        // Stops the game once the laps are completed
        scoreboard.SetActive(true);
        playerLapper.checkpointIndex = 0;
        playerLapper.lap = 1;
        Time.timeScale = 0;
        GameManager.isPlayable = false;
    }

    public void MainMenu()
    {
        // Return to the main menu
        playerLapper.checkpointIndex = 0;
        playerLapper.lap = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
=======
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
>>>>>>> Stashed changes
    }
}
