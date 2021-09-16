using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCharacterController : MonoBehaviour
{
    CharacterController spell;
    //[HideInInspector]
    public PlayerController playerCasting;
    
	public float maxDistance;

    private void Awake()
    {
        spell = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movDir = new Vector3(playerCasting.moveDirection.x, 0.0f, playerCasting.moveDirection.z);

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
