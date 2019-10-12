using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public float masterVolume = 100f;

    float timer = 0f;

    public AudioSource backgroundMusic;

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

        sources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.name == "Background Music")
            {
                source.volume = masterVolume/100;
                Debug.Log("We have identified the background music!");
            }
            else
            {
                source.volume = masterVolume / 100;
            }
        }
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
                source.volume = masterVolume/100;
            }
            else
            {
                source.volume = masterVolume/100;
            }
        }
    }

    IEnumerator Fade()
    {
        if (UIScript.changeScenesOut == true) {
            for (float alpha = 1f; alpha >= -0.05f; alpha -= .05f)
            {

                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
