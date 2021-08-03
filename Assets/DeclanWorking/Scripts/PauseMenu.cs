using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Gamepad gamepad;
    Keyboard keyboard;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject[] selectablePauseMenuOptions;

    bool isPaused = false;
    bool isOptionsShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        gamepad = Gamepad.current;
        keyboard = Keyboard.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            print(EventSystem.current.currentSelectedGameObject);
        }
        if (keyboard.escapeKey.wasPressedThisFrame || gamepad.startButton.wasPressedThisFrame)
        {  
            pauseMenu.SetActive(isPaused = isPaused ? false: true);
            optionsMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(selectablePauseMenuOptions[0]);
            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                isOptionsShowing = false;
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        print(isPaused);
        Time.timeScale = 1;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(selectablePauseMenuOptions[1]);
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(selectablePauseMenuOptions[2]);
    }

    public void ExitToMenu()
    {
      // SceneManager.LoadScene(0);
    }



}
