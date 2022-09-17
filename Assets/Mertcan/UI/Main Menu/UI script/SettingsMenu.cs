using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //Ses Müzik
    public AudioMixer am;

    public void SetMasterVolume(float value)
    {
        am.SetFloat("Master Volume", value);

    }
    public void SetMusicVolume(float value)
    {
        am.SetFloat("Music Volume", value);

    }


    //Çözünürlülük
    public void SetResoulation(int index)
    {
        if (index==0)
        {
            Screen.SetResolution(1920, 1080, isFullScreen);
        }
        if (index == 1)
        {
            Screen.SetResolution(1280, 720, isFullScreen);
        }
        if (index == 2)
        {
            Screen.SetResolution(1266, 768, isFullScreen);
        }
        if (index == 3)
        {
            Screen.SetResolution(640, 480, isFullScreen);
        }

    }
    private bool isFullScreen = true;
    public void SetFullScreen(bool fullscreen_enable)
    {
        Screen.fullScreen = fullscreen_enable;
        isFullScreen = fullscreen_enable;
    }


    // Fare Hassasiyeti
    public void SetMouseSensitivity(float value)
    {


    }

    


}
