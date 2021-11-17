using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider sfxSlider;
    public Slider musicSlider;
    void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("Sound");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    // Update is called once per frame


    public void OnDragSFX()
    {
        PlayerPrefs.SetFloat("Sound", sfxSlider.value);
    }

    public void OnDragMusic()
    {
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
}
