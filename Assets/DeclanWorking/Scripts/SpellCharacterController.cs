using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCharacterController : MonoBehaviour
{
    CharacterController spell;
	[HideInInspector]
    public PlayerController playerCon;
    
	public float maxDistance;

    private void Awake()
    {
        spell = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movDir = new Vector3(playerCon.moveDirection.x, 0.0f, playerCon.moveDirection.z);

        spell.Move(movDir * Time.deltaTime);

		// Limit the spell to a radius around the player if necessary
		Vector3 toPlayer = new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z);
		if (maxDistance > 0.0f && toPlayer.sqrMagnitude > maxDistance * maxDistance)
		{
			toPlayer.Normalize();
			toPlayer *= maxDistance;
			transform.localPosition = new Vector3(toPlayer.x, transform.localPosition.y, toPlayer.z);
		}
    }
}
