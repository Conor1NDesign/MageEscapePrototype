using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource[] audio;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectsOfType<AudioSource>();
        volume = PlayerPrefs.GetFloat("Sound");
        foreach (var item in audio)
        {
            item.volume = PlayerPrefs.GetFloat("Sound");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("Sound") != volume)
        {
            UpdateSound();
            volume = PlayerPrefs.GetFloat("Sound");
        }
    }


    public void UpdateSound()
    {
        print("Sounds Updated");
        foreach (var item in audio)
        {
            item.volume = PlayerPrefs.GetFloat("Sound");
        }
    }
}
