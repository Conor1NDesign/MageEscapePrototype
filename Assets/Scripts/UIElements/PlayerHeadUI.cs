using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeadUI : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;

    public GameObject pickupPromptGamepad;
    public GameObject pickupPromptKeyboard;
    public GameObject leverPromptGamepad;
    public GameObject leverPromptKeyboard;

    public GameObject throwMeter;
    public Image throwBarFill;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerController.playerState == PlayerController.PlayerStates.Throwing)
        {
            throwMeter.SetActive(true);
            throwBarFill.fillAmount = playerController.currentThrowStrength / playerController.throwStrength;
        }
        else
            throwMeter.SetActive(false);

        if (playerController.spellbook != null)
        {
            pickupPromptGamepad.SetActive(false);
            pickupPromptKeyboard.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            if (playerController.inputDevice == "Keyboard")
            {
                leverPromptKeyboard.SetActive(true);
            }
            else
                leverPromptGamepad.SetActive(true);
        }


        if (other.tag == "Spellbook" && other.transform.parent.GetComponent<SpellbookController>().playerHolding == null)
        {
            if (playerController.inputDevice == "Keyboard")
            {
                pickupPromptKeyboard.SetActive(true);
            }
            else
                pickupPromptGamepad.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            if (playerController.inputDevice == "Keyboard")
            {
                leverPromptKeyboard.SetActive(false);
            }
            else
                leverPromptGamepad.SetActive(false);
        }


        if (other.tag == "Spellbook")
        {
            if (playerController.inputDevice == "Keyboard")
            {
                pickupPromptKeyboard.SetActive(false);
            }
            else
                pickupPromptGamepad.SetActive(false);
        }
    }
}
