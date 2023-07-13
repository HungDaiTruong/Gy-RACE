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

        List<string> resolutionOptions = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution res = resolutions[i];
            string option = res.width + " x " + res.height;
            resolutionOptions.Add(option);
        }

        dropdownResolution.AddOptions(resolutionOptions);

        fullScreenToggle.onValueChanged.AddListener(SetFullscreen);

        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.GraphicUpdateComplete();
    }

    // Sets the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        int targetWidth = resolution.width;
        int targetHeight = resolution.height;

        // Calculate target width based on aspect ratio
        float targetAspectRatio = (float)targetWidth / targetHeight;

        // Find the closest width that matches the target aspect ratio
        int closestWidth = 0;
        float closestAspectRatio = float.MaxValue;

        foreach (Resolution res in resolutions)
        {
            float aspectRatio = (float)res.width / res.height;

            if (Mathf.Abs(aspectRatio - targetAspectRatio) < Mathf.Abs(closestAspectRatio - targetAspectRatio))
            {
                closestWidth = res.width;
                closestAspectRatio = aspectRatio;
            }
        }

        targetWidth = closestWidth;
        targetHeight = Mathf.RoundToInt(targetWidth / targetAspectRatio);

        Screen.SetResolution(targetWidth, targetHeight, Screen.fullScreen);
        Camera.main.aspect = targetAspectRatio;
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
