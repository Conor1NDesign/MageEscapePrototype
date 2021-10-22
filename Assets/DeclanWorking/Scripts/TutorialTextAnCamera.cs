using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextAnCamera : MonoBehaviour
{
    public bool requiresBothPlayers;

    [Header("Camera")]
    public bool useCameraPoint;
    public GameObject[] cameraPoint;
    public int[] cameraSwapOnTextBoxNum;
    private int camIndex = 0;

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

    public GameObject spellCanvas;

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
                        cameraPoint[0].SetActive(true);
                        mainCamera.SetActive(false);
                    }
                    gameManager.GetComponent<TutorialManager>().ttac = gameObject.GetComponent<TutorialTextAnCamera>();
                    text.text = UIText[0];
                    Canvas.SetActive(true);
                    spellCanvas.SetActive(false);
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
                    cameraPoint[0].SetActive(true);
                    mainCamera.SetActive(false);
                }
                gameManager.GetComponent<TutorialManager>().ttac = gameObject.GetComponent<TutorialTextAnCamera>();
                text.text = UIText[0];
                Canvas.SetActive(true);
                spellCanvas.SetActive(false);
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
            foreach (var item in cameraPoint)
            {
            item.SetActive(false);

            }
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

        spellCanvas.SetActive(true);
    }
    public void CheckIfCamNeedsToBeChanged()
    {
        if (cameraSwapOnTextBoxNum.Length != 0)
        {
            if (cameraSwapOnTextBoxNum[camIndex] == index)
            {

                cameraPoint[camIndex + 1].SetActive(true);
                cameraPoint[camIndex].SetActive(false);
                camIndex++;
            }
        }
    }
}

public class TutorialManager : MonoBehaviour
{
    public TutorialTextAnCamera ttac;
}
