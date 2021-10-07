using System;
using UnityEngine;

public class SpellbookController : MonoBehaviour
{
    [Tooltip("The element of this spellbook")]
    public PlayerController.PlayerCurrentElement element = PlayerController.PlayerCurrentElement.None;
    [Tooltip("Where this spellbook respawns")]
    public Transform spellbookRespawnPoint;
    [Tooltip("How long it takes for the spellbook to burn")]
    public float burnTime = 2;
    //[HideInInspector]
    public bool burning = false;
    [HideInInspector]
    public PlayerController playerHolding = null;

    private float timeBurning = 0.0f;
    private Rigidbody spellbookRB;

    private void Awake()
    {
        spellbookRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (burning)
        {
            timeBurning += Time.deltaTime;
            if (timeBurning > burnTime)
            {
                Respawn();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        SpinningBlade sb = other.GetComponent<SpinningBlade>();
        if (sb)
            Respawn();
    }

    public void Respawn()
    {
        if (playerHolding)
            playerHolding.DropSpellbook();

        burning = false;
        timeBurning = 0.0f;

        spellbookRB.velocity = new Vector3();
        spellbookRB.ResetInertiaTensor();

        transform.position = spellbookRespawnPoint.position;
        transform.rotation = spellbookRespawnPoint.rotation;
    }
}
