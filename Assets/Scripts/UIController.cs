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
    public GameObject Wipe;

    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI qualityText;

    public CanvasGroup UI;
    public CanvasGroup WipeGroup;

    string[] names;

    string currentQuality;

    int qualityIndex;

    public bool changeScenesOut = false;
    public bool changeScenesIn = true;

    bool continuing = false;

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
        settingsVolume.value = audioScript.masterVolume;
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

        StartCoroutine("FadeIn");
        audioScript.StartCoroutine("FadeIn");
    }

    public void StartGame()
    {
        //Fade the camera and load the scene.
        Wipe.SetActive(true);
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");
    }

    public void ExitGame()
    {
        //Save the current settings, and close the application.
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void ContinueGame()
    {
        //Load the last level you were on.
        continuing = true;
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");
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

        PlayerPrefs.SetString("Quality Level", names[qualityIndex]);
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

        PlayerPrefs.SetString("Quality Level", names[qualityIndex]);
    }

    IEnumerator FadeOut()
    {
        for (float alpha = 1f; alpha >= -0.05f; alpha -= .05f)
        {
            UI.alpha = alpha;
            WipeGroup.alpha = 1f - alpha;

            if (alpha <= 0f && continuing == true)
            {
                SceneManager.LoadScene(PlayerPrefs.GetString("Last Level"));
            }
            else if (alpha <= 0f && continuing == false)
            {
                SceneManager.LoadScene("Level 1");
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float alpha = 1f; alpha >= -0.05f; alpha -= .05f)
        {
            UI.alpha = 1f - alpha;
            WipeGroup.alpha = alpha;

            if (alpha <= 0f)
            {
                Wipe.SetActive(false);
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
