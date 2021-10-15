using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject[] selectablePauseMenuOptions;

    bool isPaused = false;
    // bool isOptionsShowing = false;



    public void Pause()
    {
        
        pauseMenu.SetActive(isPaused = !isPaused);

        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(selectablePauseMenuOptions[0]);
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        EventSystem.current.SetSelectedGameObject(selectablePauseMenuOptions[0]);
    }

    public void ExitToMenu()
    {
         SceneManager.LoadScene(0);
    }



}
