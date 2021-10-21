using System.Collections;
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
    public GameObject bookToTrigger;

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

    void Start()
    {
        players = FindObjectsOfType<PlayerController>();
        mainCamera = Camera.main.gameObject;
        gameManager = GameObject.Find("GameManager");
        if (gameManager.GetComponent<TutorialManager>() == null)
        {
            gameManager.AddComponent<TutorialManager>();
        }
        text = Canvas.GetComponentInChildren<TextMeshProUGUI>();
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
    }


}

public class TutorialManager : MonoBehaviour
{
    public TutorialTextAnCamera ttac;
}
