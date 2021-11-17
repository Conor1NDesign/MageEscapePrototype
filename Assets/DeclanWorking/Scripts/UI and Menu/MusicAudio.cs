using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : MonoBehaviour
{

    float value = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

        value = PlayerPrefs.GetFloat("Music");
        GetComponent<AudioSource>().volume = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("Music") != value)
        {
            value = PlayerPrefs.GetFloat("Music");
            UpdateSound();
        }
    }

    public void UpdateSound()
    {
        GetComponent<AudioSource>().volume = value;
    }
}
