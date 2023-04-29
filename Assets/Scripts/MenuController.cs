using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

enum MenuState
{
    MainMenu, MapSelector, LevelSelector, CustomSelector
};

public class MenuController : MonoBehaviour
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


    public void changeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
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

    public void ChooseMap(GameObject MapButton)
    {
        List<GameObject> children = getChildren(menuMap);
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }

        MapButton.SetActive(true);
        ButtonBack.SetActive(true);
        posTMP = MapButton.transform.position;
        scaleTMP = MapButton.transform.localScale;
        MapButton.transform.position = PosMapLevelSelector.transform.position;
        MapButton.transform.localScale = new Vector3(2, 2, 2);

        ButtonsLevel.SetActive(true);
        MapSelected = MapButton;
        State = MenuState.LevelSelector;
        MapButtonTMP = MapButton;
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

        Dictionary<string, string> bindingMapScene = new Dictionary<string, string>();

        bindingMapScene.Add("ButtonMonaco", "MapMonaco");
        bindingMapScene.Add("ButtonSPA", "MapSpa");
        bindingMapScene.Add("ButtonRicardo", "MapRicardo");
        bindingMapScene.Add("ButtonMans", "MapLeMan");
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

