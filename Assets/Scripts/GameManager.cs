using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPlayable = true;

    public GameObject pauseCanvas;

    private PlayerControls inputActions;

    private bool pauseInput;
    private bool paused = false;

    public void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        isPlayable = true;
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pauseInput = inputActions.UI.Pause.WasPressedThisFrame();

        Pausing();
    }

    private void Pausing()
    {
        if(pauseInput && isPlayable)
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        paused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
