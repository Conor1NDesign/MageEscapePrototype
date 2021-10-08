using UnityEngine;

public class SpellCharacterController : MonoBehaviour
{
	CharacterController spell;
	//[HideInInspector]
	public PlayerController playerCasting;
	public bool useGravity = false;

	public float maxDistance;

	private void Awake()
	{
		spell = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if (playerCasting.spellbook == null)
		{
			playerCasting.tornadoActive = false;
			Destroy(gameObject);
		}
		if (playerCasting)
		{
			Vector3 movDir = new Vector3(playerCasting.moveDirection.x, useGravity ? playerCasting.moveDirection.y : 0, playerCasting.moveDirection.z);
			print(movDir);
			spell.Move(movDir * Time.deltaTime);

			// Limit the spell to a radius around the player if necessary
			Vector3 toPlayer = new Vector3(transform.position.x, 0.0f, transform.position.z)
				- new Vector3(playerCasting.transform.position.x, 0.0f, playerCasting.transform.position.z);
			if (maxDistance > 0.0f && toPlayer.sqrMagnitude > maxDistance * maxDistance)
			{
				toPlayer.Normalize();
				toPlayer *= maxDistance;
				transform.position = new Vector3(toPlayer.x + playerCasting.transform.position.x,
					transform.position.y,
					toPlayer.z + playerCasting.transform.position.z);
			}
		}
	}
}
