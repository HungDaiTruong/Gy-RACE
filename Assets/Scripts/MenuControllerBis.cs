using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuControllerBis : MonoBehaviour
{
    [SerializeField]
    private GameObject menuMap;
    [SerializeField]
    private GameObject MapLevel;
    [SerializeField]
    private GameObject menuMapOriginal;
    [SerializeField]
    private GameObject mainMenu;

    private GameObject MapButtonTMP;
    private Vector3 posTMP;
    private Vector3 scaleTMP;

    [SerializeField]
    private Transform PosMapLevelSelector;
    [SerializeField]
    private GameObject ButtonsLevel;
    [SerializeField]
    private GameObject ButtonBack;
    [SerializeField]
    private GameObject CanvaCustom;

    [SerializeField]
    private GameObject MapSelected;
    private GameObject LevelSelected;





    private MenuState State;


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        menuMap.SetActive(true);
        State = MenuState.MapSelector;
    }

    public void Back()
    {

        if (State == MenuState.MapSelector)
        {
            mainMenu.SetActive(true);
            menuMap.SetActive(false);
            State = MenuState.MainMenu;
            MapSelected = null;
        }


        if (State == MenuState.LevelSelector)
        {
            List<GameObject> children = getChildren(menuMap);
            foreach (GameObject child in children)
            {
                child.SetActive(true);
            }
            State = MenuState.MapSelector;

            ButtonsLevel.SetActive(false);

            MapButtonTMP.transform.position = posTMP;
            MapButtonTMP.transform.localScale = scaleTMP;
        }
    }

    public void ChooseMap(GameObject mapButton)
    {
        List<GameObject> children = getChildren(menuMap);
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }

        mapButton.SetActive(true);
        ButtonBack.SetActive(true);
        posTMP = mapButton.transform.position;
        scaleTMP = mapButton.transform.localScale;
        mapButton.transform.position = PosMapLevelSelector.transform.position;
        mapButton.transform.localScale = new Vector3(2, 2, 2);

        ButtonsLevel.SetActive(true);
        MapSelected = mapButton;
        State = MenuState.LevelSelector;
        MapButtonTMP = mapButton;
    }
    public void Quit()
    {
        Application.Quit();
    }

    private List<GameObject> getChildren(GameObject unObject)
    {
        List<GameObject> children = new();
        int nbChild = unObject.transform.childCount;
        Debug.Log(nbChild);
        for (int i = 0; i < nbChild; i++)
        {
            children.Add(unObject.transform.GetChild(i).gameObject);
        }
        return children;
    }

    void StartGame()
    {
        print(MapSelected);
        print(LevelSelected);

        Dictionary<string, string> bindingMapScene = new()
        {
            { "ButtonMonaco", "MapMonaco" },
            { "ButtonSPA", "MapSpa" },
            { "ButtonRicardo", "MapRicardo" },
            { "ButtonMans", "MapLeMan" }
        };
    }

    public void ChooseLevel(GameObject LevelGame)
    {
        LevelSelected = LevelGame;
        menuMap.SetActive(false);
        CanvaCustom.SetActive(true);
        StartGame();
    }

    /*public void CustomGame()
    {

    }*/
}

