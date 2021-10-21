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
    public string CurrentUIText;
    GameObject mainCamera;
    public GameObject Canvas;
    public TextMeshProUGUI text;
    int index;
    GameObject gameManager;

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

    int counter;
    // Update is called once per frame
    void Update()
    {

    }


    int playerInTrigger;
    private void OnTriggerEnter(Collider other)
    {

        if (!AlreadyTriggered)
        {
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger--;
        }
    }

    public string nextText()
    {
        print("aaaaa");
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
