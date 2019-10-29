using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public AudioController audioScript;
    public PlayerMovment playerScript;
    public GameController gameScript;

    public AudioSource touchSounds;

    public Slider settingsVolume;

    public GameObject settings;
    public GameObject Wipe;

    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI qualityText;

    public CanvasGroup UI;
    public CanvasGroup WipeGroup;

    Scene name;

    string[] names;

    string currentQuality;

    int qualityIndex;

    public bool changeScenesOut = false;
    public bool changeScenesIn = true;

    bool hasDied = false;
    bool continuing = false;
    bool pause = false;

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
        name = SceneManager.GetActiveScene();

        if (name.name != "Main Menu")
        {
            playerScript = GameObject.Find("Ninja_01").GetComponent<PlayerMovment>();
            gameScript = GameObject.Find("Enemy Handler").GetComponent<GameController>();
            continuing = true;
        }

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
    }

    public void Update()
    {
        if (name.name != "Main Menu")
        {
            if ((playerScript.currentHealth <= 0f) && !hasDied && playerScript.dead)
            {
                Wipe.SetActive(true);
                PlayerPrefs.Save();
                hasDied = true;
                StartCoroutine("FadeOut");
                audioScript.StartCoroutine("FadeOut");
            }
            else if (playerScript.currentHealth > 0f && !playerScript.dead && gameScript.wavesComplete)
            {
                Wipe.SetActive(true);

                if (name.name == "Level 1")
                {
                    PlayerPrefs.SetString("Last Level", "Level 2");
                }
                else if (name.name == "Level 2")
                {
                    PlayerPrefs.SetString("Last Level", "Level 3");
                }
                else if (name.name == "Level 3")
                {
                    PlayerPrefs.SetString("Last Level", "Level 4");
                }
                else if (name.name == "Level 4")
                {
                    PlayerPrefs.SetString("Last Level", "Level 4");
                }

                continuing = true;
                PlayerPrefs.Save();
                StartCoroutine("FadeOut");
                audioScript.StartCoroutine("FadeOut");
            }
        }
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
        Wipe.SetActive(true);
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
            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            settings.SetActive(true);
            Time.timeScale = 0;
            pause = true;
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

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("Not playing the game RIP.");
            Time.timeScale = 0;
        }
    }

    public void LoadMainMenu()
    {
        continuing = true;
        pause = false;
        Time.timeScale = 1;
        Wipe.SetActive(true);
        PlayerPrefs.SetString("Last Level", "Main Menu");
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");
    }

    public void LoadLevel1()
    {
        continuing = true;
        pause = false;
        Time.timeScale = 1;
        Wipe.SetActive(true);
        PlayerPrefs.SetString("Last Level", "Level 1");
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");
    }

    public void LoadLevel2()
    {
        continuing = true;
        pause = false;
        Time.timeScale = 1;
        Wipe.SetActive(true);
        PlayerPrefs.SetString("Last Level", "Level 2");
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");
    }

    public void LoadLevel3()
    {
        continuing = true;
        pause = false;
        Time.timeScale = 1;
        Wipe.SetActive(true);
        PlayerPrefs.SetString("Last Level", "Level 3");
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");
    }

    public void LoadLevel4()
    {
        continuing = true;
        pause = false;
        Time.timeScale = 1;
        Wipe.SetActive(true);
        PlayerPrefs.SetString("Last Level", "Level 4");
        PlayerPrefs.Save();
        StartCoroutine("FadeOut");
        audioScript.StartCoroutine("FadeOut");

    }

    IEnumerator FadeOut()
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            UI.alpha = alpha;
            WipeGroup.alpha = 1f - alpha;

            if (alpha <= 0.05f && hasDied)
            {
                SceneManager.LoadScene(name.name);
            }
            else if (alpha <= 0.05f && continuing == true)
            {
                SceneManager.LoadScene(PlayerPrefs.GetString("Last Level"));
            }
            else if (alpha <= 0.05f && continuing == false)
            {
                SceneManager.LoadScene("Level 1");
            }

            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            UI.alpha = 1f - alpha;
            WipeGroup.alpha = alpha;

            if (alpha <= 0.05f)
            {
                Wipe.SetActive(false);
            }

            yield return new WaitForSeconds(0f);
        }
    }
}
