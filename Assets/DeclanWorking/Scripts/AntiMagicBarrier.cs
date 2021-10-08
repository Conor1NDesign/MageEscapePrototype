﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMagicBarrier : MonoBehaviour
{

    PlayerController[] casters;

    // Start is called before the first frame update
    void Start()
    {
        casters = FindObjectsOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spellbook"))
        {
            foreach (var item in casters)
            {
                if (item.spellbook == other.gameObject)
                {
                    other.attachedRigidbody.isKinematic = false;
                    item.spellbook = null;
                    item.playerElement = PlayerController.PlayerCurrentElement.None;
                }
            }
                    other.transform.parent = null;
                    other.GetComponent<SpellbookController>().Respawn();
        }

        if (other.gameObject.layer == 8)
        {
            PlayerController caster = other.GetComponent<SpellCharacterController>().playerCasting;
            caster.tornadoActive = false;
            caster.tornado = null;
            Destroy(other.gameObject);

        }
    }
}
