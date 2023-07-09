using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject cameraPlayer1;
    public GameObject cameraPlayer2;

    public GameObject vehiclePreviewPlayer1;
    public GameObject vehiclePreviewPlayer2;

    public GameObject mainMenu;
    public GameObject mapMenu;
    public GameObject difficultyMenu;
    
    public GameObject uiGroup;

    public GameObject chosenMapDisplay;

    public bool isMultiplayer = false;
    public bool playerOneReady = false;
    public bool playerTwoReady = false;

    [SerializeField]
    public static string mapSelected;
    [SerializeField]
    private string difficultySelected;

    void Start()
    {
        // Deactivate all the unecessary UI and components of the vehicles in the menu
        vehiclePreviewPlayer1.transform.GetChild(1).gameObject.SetActive(false);
        vehiclePreviewPlayer1.transform.GetChild(2).gameObject.SetActive(false);
        vehiclePreviewPlayer1.transform.GetChild(3).gameObject.SetActive(false);
        vehiclePreviewPlayer1.transform.GetChild(4).gameObject.SetActive(false);

        vehiclePreviewPlayer2.transform.GetChild(1).gameObject.SetActive(false);
        vehiclePreviewPlayer2.transform.GetChild(2).gameObject.SetActive(false);
        vehiclePreviewPlayer2.transform.GetChild(3).gameObject.SetActive(false);
        vehiclePreviewPlayer1.transform.GetChild(4).gameObject.SetActive(false);

        vehiclePreviewPlayer1.SetActive(false);
        vehiclePreviewPlayer2.SetActive(false);

        // Set the camera to no-split
        cameraPlayer2.SetActive(false);
        cameraPlayer1.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);

        // Deactivate all the UIs
        foreach (Canvas canvas in uiGroup.GetComponentsInChildren<Canvas>())
        {
            canvas.gameObject.SetActive(false);
        }

        // Activate the main UI
        mainMenu.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        // If solo then activate the Player One else activate both Players
        if (!isMultiplayer)
        {
            SceneManager.LoadScene(sceneName);
            vehiclePreviewPlayer1.GetComponent<PlayerLocomotion>().EnableMovements();
            vehiclePreviewPlayer1.transform.GetChild(1).gameObject.SetActive(true);
            vehiclePreviewPlayer1.transform.GetChild(2).gameObject.SetActive(true);
            vehiclePreviewPlayer1.transform.GetChild(3).gameObject.SetActive(true);
            vehiclePreviewPlayer1.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            if(playerOneReady && playerTwoReady)
            {
                SceneManager.LoadScene(sceneName);
                vehiclePreviewPlayer1.GetComponent<PlayerLocomotion>().EnableMovements();
                vehiclePreviewPlayer1.transform.GetChild(1).gameObject.SetActive(true);
                vehiclePreviewPlayer1.transform.GetChild(2).gameObject.SetActive(true);
                vehiclePreviewPlayer1.transform.GetChild(3).gameObject.SetActive(true);
                vehiclePreviewPlayer1.transform.GetChild(4).gameObject.SetActive(true);

                vehiclePreviewPlayer2.GetComponent<PlayerLocomotion>().EnableMovements();
                vehiclePreviewPlayer2.transform.GetChild(1).gameObject.SetActive(true);
                vehiclePreviewPlayer2.transform.GetChild(2).gameObject.SetActive(true);
                vehiclePreviewPlayer2.transform.GetChild(3).gameObject.SetActive(true);
                vehiclePreviewPlayer2.transform.GetChild(4).gameObject.SetActive(true);
            }
        }
    }

    public void ChooseMap(Image image)
    {
        // The chosen map's value is stored as a string according to its button's name in the menu
        mapSelected = image.gameObject.name;
        chosenMapDisplay.GetComponent<Image>().sprite = image.sprite;
    }

    public void ChooseDifficulty(Button button)
    {
        // Select the difficulty according to the buttons' names
        difficultySelected = button.name;
    }

    public void OnMultiplayerButtonClick()
    {
        // Method used to setup the multiplayer split screen cameras
        isMultiplayer = true;

        cameraPlayer1.GetComponent<Camera>().rect = new Rect(-0.5f, 0f, 1f, 1f);
        cameraPlayer1.SetActive(true);
        cameraPlayer2.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 1f, 1f);
        cameraPlayer2.SetActive(true);
    }

    public void PlayerOneReady()
    {
        // Player One applied the customization
        playerOneReady = true;
    }

    public void PlayerTwoReady()
    {
        // Player Two applied the customization
        playerTwoReady = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
