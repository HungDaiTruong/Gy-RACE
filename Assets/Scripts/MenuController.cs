using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject initialMenu;
    public GameObject vehiclePreview;
    public GameObject allUI;

    void Start()
    {
        vehiclePreview.transform.GetChild(1).gameObject.SetActive(false);

/*        foreach (Canvas canvas in allUI.GetComponentsInChildren<Canvas>())
        {
            canvas.gameObject.SetActive(false);
        }

        initialMenu.SetActive(true);
        vehiclePreview.SetActive(false);*/
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
