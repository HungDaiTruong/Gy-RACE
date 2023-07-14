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
    public TMP_Dropdown dropdownResolution;
    public TMP_Dropdown dropdownQuality;
    public Toggle fullScreenToggle;
    public Slider volumeSlider;

    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;

    public int currentResolutionIndex;

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

        // Get the resolutions and refresh rate 
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        dropdownResolution.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        // Filters them to only get the ones that matches the refresh rate of the screen
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        // What the dropdown will display, resolution and hertz
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Setup the dropdown values and select the current resolution of the screen
        dropdownResolution.AddOptions(options);
        dropdownResolution.value = Mathf.Max(options.Count);
        dropdownResolution.RefreshShownValue();
    }

    private void Start()
    {
        fullScreenToggle.onValueChanged.AddListener(SetFullscreen); // Fullscreen toggle
        volumeSlider.onValueChanged.AddListener(SetVolume); // Volume slider
        volumeSlider.GraphicUpdateComplete(); // Updates the slider
    }

    // Sets the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, fullScreenToggle.isOn);
    }

    // Sets the menu volume
    public void SetVolume (float volume)
    {
        audioSource.volume = volume;
    }

    // Sets the quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, false);
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
                iterations[1].dropdownResolution.value = iterations[0].dropdownResolution.value;
                iterations[1].dropdownQuality.value = iterations[0].dropdownQuality.value;
                iterations[1].fullScreenToggle.isOn = iterations[0].fullScreenToggle.isOn;

                Destroy(iterations[0].gameObject);
            }

            audioSource.clip = audioClips[0];
            audioSource.volume = volumeSlider.value;
            audioSource.Play();
        }
    }
}
