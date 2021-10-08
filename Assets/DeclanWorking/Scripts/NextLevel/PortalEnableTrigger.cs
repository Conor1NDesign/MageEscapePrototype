using UnityEngine;

public class PortalEnableTrigger : MonoBehaviour
{
	public GameObject portal;
	void Update()
	{
		if (playerCount == 2)
		{
			portal.SetActive(true);
		}
		else
		{
			portal.SetActive(false);
		}
	}

	public int playerCount;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			playerCount++;
		}
	}


	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			playerCount--;
		}
	}
}
