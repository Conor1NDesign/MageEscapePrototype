﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextAnCamera : MonoBehaviour
{
    public bool requiresBothPlayers;
    public bool useCameraPoint;
    public GameObject cameraPoint;

    public string[] UIText;

    public bool requiresBook;
    private GameObject bookToTrigger;

    [HideInInspector]
    public string CurrentUIText;

    GameObject mainCamera;

    public GameObject Canvas;

    [HideInInspector]
    public TextMeshProUGUI text;

    int index;

    GameObject gameManager;

    int playerInTrigger;

    [HideInInspector]
    public PlayerController[] players;
    bool AlreadyTriggered = false;


    [Header("TriggerSequence")]
    public GameObject[] nextTrigger;
    public GameObject[] triggerOff;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        if (gameManager.GetComponent<TutorialManager>() == null)
        {
            gameManager.AddComponent<TutorialManager>();
        }
    }
    void Start()
    {
        if (requiresBook)
        {
            bookToTrigger = gameObject;
        }
        players = FindObjectsOfType<PlayerController>();
        mainCamera = Camera.main.gameObject;
        /*        gameManager = GameObject.Find("GameManager");
                if (gameManager.GetComponent<TutorialManager>() == null)
                {
                    gameManager.AddComponent<TutorialManager>();
                }*/
        text = Canvas.GetComponentInChildren<TextMeshProUGUI>();
        if (nextTrigger.Length != 0)
        {
            foreach (var trigger in nextTrigger)
            {

                trigger.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (requiresBook)
        {
            if (!AlreadyTriggered)
            {
                if (bookToTrigger.transform.parent != null)
                {
                    index = 0;

                    foreach (var item in players)
                    {
                        item.enabled = false;
                        item.animator.SetInteger("State", (int)0);
                    }
                    if (useCameraPoint)
                    {
                        cameraPoint.SetActive(true);
                        mainCamera.SetActive(false);
                    }
                    gameManager.GetComponent<TutorialManager>().ttac = gameObject.GetComponent<TutorialTextAnCamera>();
                    text.text = UIText[0];
                    Canvas.SetActive(true);
                    AlreadyTriggered = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !requiresBook)
        {
            if (!AlreadyTriggered)
            {
                index = 0;
                if (other.CompareTag("Player"))
                {
                    playerInTrigger++;
                }

                if (requiresBothPlayers)
                {
                    if (playerInTrigger != 2)
                    {
                        return;
                    }
                }
                foreach (var item in players)
                {
                    item.enabled = false;
                    item.animator.SetInteger("State", (int)0);
                }
                if (useCameraPoint)
                {
                    cameraPoint.SetActive(true);
                    mainCamera.SetActive(false);
                }
                gameManager.GetComponent<TutorialManager>().ttac = gameObject.GetComponent<TutorialTextAnCamera>();
                text.text = UIText[0];
                Canvas.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger--;
        }
    }

    public string nextText()
    {

        index++;
        if (index != UIText.Length)
        {
            return UIText[index];
        }
        else
        {
            return "";
        }
    }

    public void EndSequence()
    {
        foreach (var item in players)
        {
            item.enabled = true;
        }
        if (useCameraPoint)
        {
            cameraPoint.SetActive(false);
            mainCamera.SetActive(true);
        }
        Canvas.SetActive(false);
        AlreadyTriggered = true;
        gameManager.GetComponent<TutorialManager>().ttac = null;
        if (nextTrigger.Length != 0)
        {
            foreach (var trigger in nextTrigger)
            {

                trigger.SetActive(true);
            }
        }

        if (triggerOff.Length != 0)
        {
            foreach (var trigger in triggerOff)
            {

                trigger.SetActive(false);
            }
        }
    }
    private void OnDisable()
    {

    }

}

public class TutorialManager : MonoBehaviour
{
    public TutorialTextAnCamera ttac;
}
