using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
	public LevelTransition transitionScript;


	private void OnTriggerEnter(Collider other)
	{
		transitionScript.StartTransition();
	}
}
