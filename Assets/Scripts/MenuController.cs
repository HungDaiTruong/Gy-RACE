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

        cameraPlayer2.SetActive(false);
        cameraPlayer1.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);

        foreach (Canvas canvas in uiGroup.GetComponentsInChildren<Canvas>())
        {
            canvas.gameObject.SetActive(false);
        }

        mainMenu.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
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
        mapSelected = image.gameObject.name;
        chosenMapDisplay.GetComponent<Image>().sprite = image.sprite;
    }

    public void ChooseDifficulty(Button button)
    {
        difficultySelected = button.name;
    }

    public void OnMultiplayerButtonClick()
    {
        isMultiplayer = true;

        cameraPlayer1.GetComponent<Camera>().rect = new Rect(-0.5f, 0f, 1f, 1f);
        cameraPlayer1.SetActive(true);
        cameraPlayer2.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 1f, 1f);
        cameraPlayer2.SetActive(true);
    }

    public void PlayerOneReady()
    {
        playerOneReady = true;
    }

    public void PlayerTwoReady()
    {
        playerTwoReady = true;
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
