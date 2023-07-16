using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPlayable = true;

    public GameObject pauseCanvas;
    public GameObject circuitGroup;
    private MenuOption menuOption;

    private PlayerControls inputActions;

    private bool pauseInput;
    private bool paused = false;

    public int currentCircuit = 0;

    private void Awake()
    {
        // Disables all but the selected racing circuit for the Time Trial Mode
        if (MenuController.modeSelected == "TT")
        {
            GameObject chosenCircuit = GameObject.Find(MenuController.mapSelected);
            foreach (Transform t in circuitGroup.transform)
            {
                t.gameObject.SetActive(t.gameObject == chosenCircuit);
            }
        }
        else if (MenuController.modeSelected == "GP")
        {
            ActivateGPCircuit();
        }

        DestroyItems();
    }

    // Enables the input registration
    public void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
    }

    // Disables the input registration
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        isPlayable = true;
        pauseCanvas.SetActive(false);

        menuOption = FindObjectOfType<MenuOption>();
    }

    // Update is called once per frame
    void Update()
    {
        pauseInput = inputActions.UI.Pause.WasPressedThisFrame();

        Pausing();
    }

    private void Pausing()
    {
        // Toggles the Pause Menu if the game is deemed playable
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
        // Stops the game and enable the menu
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        paused = true;
    }

    public void ResumeGame()
    {
        // Resumes the game and disable the menu
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        menuOption.transform.GetChild(1).gameObject.SetActive(false);
        paused = false;
    }

    public void MainMenu()
    {
        DestroyItems();

        // Return to the main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void Option()
    {
        // Return to the option
        Time.timeScale = 0;

        menuOption.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void DestroyItems()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            Destroy(item);
        }
    }

    public void ActivateGPCircuit()
    {
        foreach (Transform t in circuitGroup.transform)
        {
            t.gameObject.SetActive(t.GetSiblingIndex() == currentCircuit);
        }
    }
}
