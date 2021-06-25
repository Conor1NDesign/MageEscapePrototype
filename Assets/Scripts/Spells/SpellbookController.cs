using System;
using UnityEngine;

public class SpellbookController : MonoBehaviour
{
    [Tooltip("The element of this spellbook")]
    public PlayerController.PlayerCurrentElement element = PlayerController.PlayerCurrentElement.None;
    [Tooltip("Where this spellbook respawns")]
    public Transform spellbookRespawnPoint;

    private Rigidbody spellbookRB;

    private void Awake()
    {
        spellbookRB = GetComponent<Rigidbody>();
    }

    public void Respawn()
    {
        spellbookRB.velocity = new Vector3();
        spellbookRB.ResetInertiaTensor();

        transform.position = spellbookRespawnPoint.position;
        transform.rotation = spellbookRespawnPoint.rotation;
    }
}
