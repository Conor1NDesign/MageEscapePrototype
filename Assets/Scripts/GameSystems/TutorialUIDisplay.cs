using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIDisplay : MonoBehaviour
{
    public Image linkedUIElement;
    public float fadeSpeed;
    private bool playerInTrigger = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = false;
        }    
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger)
        {
            var tempColor = linkedUIElement.color;
            tempColor.a += fadeSpeed;
            if (tempColor.a >= 1)
            {
                tempColor.a = 1;
            }
            linkedUIElement.color = tempColor;
        }
        else
        {
            var tempColor = linkedUIElement.color;
            tempColor.a -= fadeSpeed;
            if (tempColor.a <= 0)
            {
                tempColor.a = 0;
            }
            linkedUIElement.color = tempColor;
        }
    }
}
