using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public AudioController audioScript;

    public AudioSource touchSounds;

    public Slider settingsVolume;

    public GameObject settings;

    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI qualityText;

    string[] names;

    string currentQuality;

    int qualityIndex;

    public void Awake()
    {
        names = QualitySettings.names;

        if (!PlayerPrefs.HasKey("Quality Level"))
        {
            currentQuality = "Medium";
            PlayerPrefs.SetString("Quality Level", "Medium");
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        settingsVolume.value = PlayerPrefs.GetFloat("Volume");
        settings = GameObject.Find("Settings Page");

        for (int i = 0; i < names.Length; i++)
        {
            if (PlayerPrefs.GetString("Quality Level") == names[i])
            {
                QualitySettings.SetQualityLevel(i, true);
                qualityText.text = names[i];
                qualityIndex = i;
            }
        }

        settings.SetActive(false);
    }

    public void StartGame()
    {
        //Fly and Tilt the Camera Up, then load the scene and fly back down.
        SceneManager.LoadScene("Level 1");
    }

    public void ExitGame()
    {
        //Save the current settings, and close the application.
        Application.Quit();
    }

    public void ContinueGame()
    {
        //Load the last level you were on.
        SceneManager.LoadScene("Level 1");
    }

    public void Settings()
    {
        //Open the settings page to edit volume and quality.
        //Or close it, depends on if the page is open.
        if (settings.activeSelf)
        {
            PlayerPrefs.Save();
            settings.SetActive(false);
        }
        else
        {
            settings.SetActive(true);
        }
    }

    public void SaveandExit()
    {
        Settings();
        PlayerPrefs.Save();
    }

    public void Volume(Slider volume)
    {
        audioScript.masterVolume = volume.value;
        volumeText.text = ("" + volume.value);
    }

    public void OnTouch()
    {
        touchSounds.Play();
    }

    public void IncreaseQuality()
    {
        if (qualityIndex < 5)
        {
            qualityIndex++;
            QualitySettings.SetQualityLevel(qualityIndex, true);
            qualityText.text = names[qualityIndex];
        }
        else
        {
            qualityIndex = 0;
            QualitySettings.SetQualityLevel(qualityIndex, true);
            qualityText.text = names[qualityIndex];
        }
    }

    public void DecreaseQuality()
    {
        if (qualityIndex > 0)
        {
            qualityIndex--;
            QualitySettings.SetQualityLevel(qualityIndex, true);
            qualityText.text = names[qualityIndex];
        }
        else
        {
            qualityIndex = 5;
            QualitySettings.SetQualityLevel(qualityIndex, true);
            qualityText.text = names[qualityIndex];
        }
    }
}
