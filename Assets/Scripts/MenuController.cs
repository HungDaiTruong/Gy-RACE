<<<<<<< Updated upstream
=======
using System;
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
<<<<<<< Updated upstream
   public void changeScene(string _sceneName)
=======
    [SerializeField]
    private GameObject menuMap;
    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private Transform PosMapLevelSelector;

    [SerializeField]
    private GameObject ButtonsLevel;


    public void changeScene(string _sceneName)
>>>>>>> Stashed changes
   {
        SceneManager.LoadScene(_sceneName);
   }

<<<<<<< Updated upstream
   public void Quit()
   {
        Application.Quit();
   }
=======
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
    }
>>>>>>> Stashed changes
}
