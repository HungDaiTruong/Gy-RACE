using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MenuState
{
    MainMenu, MapSelector, LevelSelector, CustomSelector
};

public class MenuController : MonoBehaviour
{
    private MenuState menuState;

    public GameObject mainMenu;
    public GameObject mapMenu;
    public GameObject difficultyMenu;
    public GameObject vehiclePreview;
    public GameObject uiGroup;

    public GameObject chosenMapDisplay;

    [SerializeField]
    private string mapSelected;
    [SerializeField]
    private string difficultySelected;

    void Start()
    {
        vehiclePreview.transform.GetChild(1).gameObject.SetActive(false);

        foreach (Canvas canvas in uiGroup.GetComponentsInChildren<Canvas>())
        {
            canvas.gameObject.SetActive(false);
        }

        mainMenu.SetActive(true);
        vehiclePreview.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateState(MenuState state)
    {
        menuState = state;
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

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
