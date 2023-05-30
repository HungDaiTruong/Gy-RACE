using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour
{
    public GameObject mOption;
    bool visible = false;

    public TMP_Dropdown dropdownResolution;
    public TMP_Dropdown dropdownQuality;

    public AudioMixer audioMixer;
    public AudioMixer audioMixerMusic;

    public AudioSource audioSourceMenu;

    Resolution[] resolutions;

    void Start()
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
    }

    // Sets the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Sets the menu volume
    public void SetVolumeMenu (float volumeMenu)
    {
        audioSourceMenu.volume = volumeMenu;
        print(volumeMenu);
    }

    // Sets the game volume
    public void SetVolumeGame(float volumeGame)
    {
        audioMixerMusic.SetFloat("volumeMusic", volumeGame);
    }

    // Sets the quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Toggles fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
