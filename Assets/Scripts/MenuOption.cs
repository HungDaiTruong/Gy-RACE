using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour
{
    public GameObject MOption;
    bool visible = false;

    public TMP_Dropdown DropdownResolution;
    public TMP_Dropdown DropdownQuality;

    public AudioMixer AudioMixer;
    public AudioMixer AudioMixerMusic;

    public AudioSource AudioSourceMenu;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        DropdownResolution.ClearOptions();

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

        DropdownResolution.AddOptions(options);
        DropdownResolution.value = currentResolutionIndex;
        DropdownResolution.RefreshShownValue();
    }

    void Update()
    {
        
    }

    //pour la resolution 
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //pour le volume 
    public void SetVolumeMenu (float volumeMenu)
    {
        AudioSourceMenu.volume = volumeMenu;
        print(volumeMenu);
    }

    public void SetVolumeGame(float volumeGame)
    {
        AudioMixerMusic.SetFloat("volumeMusic", volumeGame);
    }

    //pour la qualité
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
