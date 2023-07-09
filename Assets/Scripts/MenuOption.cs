using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOption : MonoBehaviour
{
    public GameObject mOption;

    public TMP_Dropdown dropdownResolution;
    public TMP_Dropdown dropdownQuality;
    public Toggle fullScreenToggle;
    public Slider volumeSlider;

    public AudioMixer audioMixer;

    public AudioSource audioSource;

    public AudioClip[] audioClips;

    Resolution[] resolutions;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        resolutions = Screen.resolutions;
        dropdownResolution.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //Resolution resolution = resolutions[i];
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;

            }
        }

        dropdownResolution.AddOptions(options);
        dropdownResolution.value = currentResolutionIndex;
        dropdownResolution.RefreshShownValue();

        fullScreenToggle.onValueChanged.AddListener(SetFullscreen);

        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.GraphicUpdateComplete();


    }

    // Sets the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Sets the menu volume
    public void SetVolume (float volume)
    {
        audioSource.volume = volume;
    }

    // Sets the quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Toggles fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        Debug.Log(Screen.fullScreenMode);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Perform actions when a new scene is loaded
        
        if(scene.name == "SampleScene")
        {
            audioSource.clip = audioClips[1];
            audioSource.volume = volumeSlider.value;
            audioSource.Play();
        }
        else
        {
            // Check for the number of iterations
            MenuOption[] iterations = FindObjectsOfType<MenuOption>();

            if (iterations.Length > 1)
            {
                iterations[1].volumeSlider.value = iterations[0].volumeSlider.value;
                Destroy(iterations[0].gameObject);
            }

            audioSource.clip = audioClips[0];
            audioSource.volume = volumeSlider.value;
            audioSource.Play();
        }
    }
}
