using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
