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
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text speedText;
    public GameObject scoreboard;

    private PlayerLocomotion playerLocomotion;
    private PlayerLapper playerLapper;
    [SerializeField]
    private PlayerLapper[] playerLappers;

    private GameObject player1;
    private GameObject player2;

    private void Awake()
    {
        playerLocomotion = GetComponentInParent<PlayerLocomotion>();
    }

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
        playerLappers = FindObjectsOfType<PlayerLapper>();

        // Ends when the 4th lap is starting, for a total of 3 laps
        if (timerOn && !(playerLapper.lap == 4 && playerLapper.checkpointIndex == 0))
        {
            time += Time.deltaTime;
            UpdateTimer(time);
            Speedometer();
        }
        else
        {
            Debug.Log(time);
            Debug.Log("Race is Finished");
            playerLocomotion.OnDisable();
            bool allFinished = true; // Flag to track if all players have finished

            foreach (PlayerLapper playerLapper in playerLappers)
            {
                // Check if any player has not finished all laps
                if (!(playerLapper.lap == 4 && playerLapper.checkpointIndex == 0))
                {
                    allFinished = false;
                    break;
                }
            }
            //GameIsDone();

            if(allFinished)
            {
                GameIsDone();
            }
        }
    }

    private void UpdateTimer(float currentTime)
    {
        // Updates the timer and displays the time, laps and checkpoints counts
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format(" {0:00}  :  {1:00}\n Lap {2}/3\n Checkpoint {3}/{4}", minutes, seconds, playerLapper.lap, playerLapper.checkpointIndex + 1, CheckpointScript.checkpointNumber);
        // Value used as a display during the scoreboard
        scoreText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
    }

    private void Speedometer()
    {
        // Displays the speed of the vehicle in km/h
        int speed = Mathf.Abs((int)transform.parent.GetComponent<PlayerLocomotion>().realSpeed);
        speedText.SetText(speed.ToString() + " km/h");
    }

    public void GameIsDone()
    {
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
    }
}
