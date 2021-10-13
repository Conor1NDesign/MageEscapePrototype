using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour
{
	public GameObject MenuCanvas;
	public GameObject OptionsCanvas;
	public GameObject LevelSelectCanvas;
	public GameObject ConfirmationCanvas;
	public EventSystem eventSystem;
	public GameObject[] firstSelectedButtons;
	
	public void NewGame()
	{
		SceneManager.LoadScene(1);
		print("NG");
	}

	public void Continue()
	{
		print("Continue");
		////------TODO-------\\\\
		////------NEEDS------\\\\
		////------Save-------\\\\
		////------DATA-------\\\\
	}

	public void LevelSelect()
	{
		MenuCanvas.SetActive(false);
		LevelSelectCanvas.SetActive(true);
		eventSystem.SetSelectedGameObject(firstSelectedButtons[5]);
		print("LS");
	}


	public void Options()
	{
		MenuCanvas.SetActive(false);
		OptionsCanvas.SetActive(true);
		eventSystem.SetSelectedGameObject(firstSelectedButtons[1]);
		print("Options");
	}

	public void Back()
	{
		MenuCanvas.SetActive(true);
		OptionsCanvas.SetActive(false);
		eventSystem.SetSelectedGameObject(firstSelectedButtons[2]);
		print("Back");
	}

	public void Exit()
	{
		ConfirmationCanvas.SetActive(true);
		eventSystem.SetSelectedGameObject(firstSelectedButtons[3]);
		print("Exit");
	}

	public void Confirm()
	{
		Application.Quit();
		print("Quiting");
	}

	public void Cancel()
	{
		ConfirmationCanvas.SetActive(false);
		eventSystem.SetSelectedGameObject(firstSelectedButtons[4]);
		print("Cancel");
	}

	public void SelectedLevel(int BuildID)
	{
		SceneManager.LoadScene(BuildID);
	}
}
