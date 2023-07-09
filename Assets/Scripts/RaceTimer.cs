using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;

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
    [SerializeField]
    private RaceTimer[] raceTimers;

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
    }

    // Update is called once per frame
    void Update()
    {
        playerLappers = FindObjectsOfType<PlayerLapper>();
        raceTimers = FindObjectsOfType<RaceTimer>();

        // Ends when the 4th lap is starting, for a total of 3 laps
        if (timerOn && !(playerLapper.lap >= 4 /*&& playerLapper.checkpointIndex == 0*/))
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
                if (!(playerLapper.lap >= 4 /*&& playerLapper.checkpointIndex == 0*/))
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
        //currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format(" {0:00}  :  {1:00}\n Lap {2}/3\n Checkpoint {3}/{4}", minutes, seconds, playerLapper.lap, playerLapper.checkpointIndex + 1, CheckpointScript.checkpointNumber);

        // Value used as a display during the scoreboard
        //scoreText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
    }

    private void Speedometer()
    {
        // Displays the speed of the vehicle in km/h
        int speed = Mathf.Abs((int)transform.parent.GetComponent<PlayerLocomotion>().realSpeed);
        speedText.SetText(speed.ToString() + " km/h");
    }

    // Stops the game once the laps are completed
    public void GameIsDone()
    {
        // Create a list to store the currentTimer values of all vehicles along with their GameObject names
        List<(float, string)> vehicleData = new List<(float, string)>();

        // Add the currentTimer and GameObject name of each RaceTimer to the list
        foreach (RaceTimer raceTimer in raceTimers)
        {
            vehicleData.Add((raceTimer.time, raceTimer.transform.parent.gameObject.name));
        }

        // Sort the vehicleData list based on currentTimer values (ascending order)
        vehicleData.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        // Calculate the maximum name length among the vehicle names
        int maxNameLength = 0;
        foreach (var data in vehicleData)
        {
            int nameLength = data.Item2.Length;
            if (nameLength > maxNameLength)
            {
                maxNameLength = nameLength;
            }
        }
        
        string filePath = "Assets/TextSite/Score.txt"; // Chemin du fichier texte

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (RaceTimer raceTimer in raceTimers)
            {
                string nom = raceTimer.transform.parent.gameObject.name;
                float temps = raceTimer.time;

                string tempsFormate = FormatTemps(temps); // Appel de la méthode pour formater le temps

                writer.WriteLine(nom + " " + tempsFormate);
            }
        }

        // Create a string to hold the formatted timer values, vehicle ranks, names, and times
        string timerSummary = "";

        // Iterate over the vehicleData list and add the formatted values to the summary string
        for (int i = 0; i < vehicleData.Count; i++)
        {
            float minutes = Mathf.FloorToInt(vehicleData[i].Item1 / 60);
            float seconds = Mathf.FloorToInt(vehicleData[i].Item1 % 60);

            string rank = (i + 1).ToString();  // Rank starts from 1
            string vehicleName = vehicleData[i].Item2;

            // Truncate or pad the vehicle name to the maximum name length
            if (vehicleName.Length > maxNameLength)
            {
                vehicleName = vehicleName.Substring(0, maxNameLength);
            }
            else
            {
                vehicleName = vehicleName.PadRight(maxNameLength);
            }

            // Format the rank, vehicle name, and time
            string formattedEntry = string.Format("<mspace=0.7em>{0,-2} {1,-8} {2,2}:{3:00}\n", rank, vehicleName, minutes, seconds);

            timerSummary += formattedEntry;
        }

        // Check if the number of vehicles is less than 8
        int remainingSlots = 8 - vehicleData.Count;
        if (remainingSlots > 0)
        {
            // Add empty slots for the remaining vehicles
            for (int i = 0; i < remainingSlots; i++)
            {
                string emptyEntry = string.Format("<mspace=0.7em>{0,-2} {1,-8} {2,5}\n", "", "", "");
                timerSummary += emptyEntry;
            }
        }

        // Set the scoreText to display the timer summary
        scoreText.text = timerSummary;

        scoreboard.SetActive(true);
        playerLapper.checkpointIndex = 0;
        playerLapper.lap = 1;
        Time.timeScale = 0;
        GameManager.isPlayable = false;
    }
    
    private string FormatTemps(float temps)
    {
        int minutes = Mathf.FloorToInt(temps / 60);
        int secondes = Mathf.FloorToInt(temps % 60);

        return string.Format("{0:00}:{1:00}", minutes, secondes);
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
