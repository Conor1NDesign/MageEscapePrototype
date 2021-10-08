using UnityEngine;

public class Boulder : MonoBehaviour
{
	public SphereCollider triggerCollider;
	public PlayerController playerCasting;

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// crush player
			PlayerController controller = other.GetComponent<PlayerController>();

			if (controller != null)
			{
				controller.isDead = true;
			}
		}
		else if (other.tag == "Spellbook")
		{
			// ignore books?
		}
		else
		{
			triggerCollider.enabled = false;
		}
	}

	public void Respawn() // Actually a destruction but named to match the spellbooks
	{
		playerCasting.boulder = null;

		Destroy(gameObject);
	}
}
