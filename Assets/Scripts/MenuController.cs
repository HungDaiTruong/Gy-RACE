<<<<<<< Updated upstream
=======
using System;
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< Updated upstream
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
        // The chosen map's value is stored as a string according to its button's name in the menu
        mapSelected = image.gameObject.name;
        chosenMapDisplay.GetComponent<Image>().sprite = image.sprite;
    }

    public void ChooseDifficulty(Button button)
    {
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
        playerOneReady = true;
    }

    public void PlayerTwoReady()
    {
        playerTwoReady = true;
    }

    public void Quit()
    {
        Application.Quit();
=======

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuMap;
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private Transform PosMapLevelSelector;

    [SerializeField]
    private GameObject ButtonsLevel;


    public void changeScene(string _sceneName)
   {
        SceneManager.LoadScene(_sceneName);
   }

   public void Play()
    {
        mainMenu.SetActive(false);
        menuMap.SetActive(true);
    }

    public void ChooseMap(GameObject MapButton)
    {
      List<GameObject> children = getChildren(menuMap);
        foreach(GameObject child in children)
        {
            child.SetActive(false);
        }

        MapButton.SetActive(true);
        MapButton.transform.position = PosMapLevelSelector.transform.position;
        MapButton.transform.localScale = new Vector3(2, 2, 2);

        ButtonsLevel.SetActive(true);

    }
    public void Quit()
   {
        Application.Quit();
   }

    private List<GameObject> getChildren(GameObject unObject)
    {
        List<GameObject> children = new List<GameObject>();
        int nbChild = unObject.transform.childCount;
        Debug.Log(nbChild);
        for(int i = 0; i < nbChild; i++)
        {
            children.Add(unObject.transform.GetChild(i).gameObject);
        }
        return children;
>>>>>>> Stashed changes
    }
}
