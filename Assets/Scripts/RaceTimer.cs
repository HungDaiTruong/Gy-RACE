using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public float time;
    public bool timerOn = false;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn && !(CheckpointScript.lap == 3 && CheckpointScript.count == 1))
        {
            time += Time.deltaTime;
            UpdateTimer(time);
        }
        else
        {
            Debug.Log(time);
            Debug.Log("Race is Finished");
            time = 0;
            GameIsDone();
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
    }

    public void GameIsDone()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
