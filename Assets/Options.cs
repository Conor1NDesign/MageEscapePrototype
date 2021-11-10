using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Sound");
    }

    // Update is called once per frame


    public void OnDrag()
    {
        PlayerPrefs.SetFloat("Sound", slider.value);
    }
}
