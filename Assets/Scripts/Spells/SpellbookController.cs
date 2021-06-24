using System;
using UnityEngine;

public class SpellbookController : MonoBehaviour
{
    [Tooltip("The element of this spellbook")]
    public PlayerController.PlayerCurrentElement element = PlayerController.PlayerCurrentElement.None;
    [Tooltip("Where this spellbook respawns")]
    public Transform spellbookRespawnPoint;

    public void Respawn()
    {
        transform.position = spellbookRespawnPoint.position;
    }
}
