using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public float masterVolume = 100f;

    float timer = 0f;

    AudioSource[] sources;

    public UIController UIScript;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 100);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        masterVolume = PlayerPrefs.GetFloat("Volume");

        Debug.Log("Volume Setting is at: " + masterVolume);

        sources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.name == "Background Music")
            {
                source.volume = masterVolume/150;
                Debug.Log("We have identified the background music!");
            }
            else if (source.name == "Crowd")
            {
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
                {
                    source.volume = masterVolume / 175;
                }
                else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 4"))
                {
                    source.volume = masterVolume / 225;
                }
                else
                {
                    source.volume = 0;
                }

                Debug.Log("We have identified the crowd's audio!");
            }
            else
            {
                source.volume = masterVolume / 100;
                Debug.Log("Setting all other sources to the max!");
            }
        }

        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            Debug.Log("Master Volume: " + masterVolume);
            timer = 0f;
        }

        if (PlayerPrefs.GetFloat("Volume") != masterVolume)
        {
            PlayerPrefs.SetFloat("Volume", masterVolume);
            UpdateAudioSources();
        }

        if (UIScript.changeScenesOut == true)
        {
            foreach(AudioSource source in sources)
            {
                if (source.volume > 0)
                {
                    source.volume -= Time.deltaTime / 3f;
                }
                else
                {
                    source.volume = 0;
                }
            }
        }
    }

    public void UpdateAudioSources()
    {
        foreach (AudioSource source in sources)
        {
            if (source.name == "Background Music")
            {
                source.volume = masterVolume / 150;
            }
            else if (source.name == "Crowd")
            {
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
                {
                    source.volume = masterVolume / 175;
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 4"))
                {
                    source.volume = masterVolume / 225;
                }
                else
                {
                    source.volume = 0;
                }
            }
            else
            {
                source.volume = masterVolume / 100;
                Debug.Log("Setting all other sources to the max!");
            }
        }
    }

    IEnumerator FadeOut()
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            foreach (AudioSource source in sources)
            {
                if (source.volume > 0)
                {
                    source.volume = alpha * (masterVolume / 100);
                }
                else
                {
                    source.volume = 0;
                }
            }

            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            foreach (AudioSource source in sources)
            {
                if (source.volume < 1)
                {
                    source.volume = (1f - alpha) * (masterVolume/100);
                }
                else
                {
                    source.volume = 1;
                }
            }

            yield return new WaitForSeconds(0f);
        }
    }
}
