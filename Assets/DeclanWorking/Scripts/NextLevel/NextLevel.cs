using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		print("Vroop");
		if (other.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}
}
