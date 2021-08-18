using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCharacterController : MonoBehaviour
{
    CharacterController spell;
    public PlayerController PlayerCon;
    public GameObject Player;
    

    private void Start()
    {
        //print(transform.position);
        spell = GetComponent<CharacterController>();

    }
    private void Update()
    {
        Vector3 movDir = new Vector3(PlayerCon.moveDirection.x, 0.0f, PlayerCon.moveDirection.z);

        spell.Move(movDir * Time.deltaTime);
    }


}


