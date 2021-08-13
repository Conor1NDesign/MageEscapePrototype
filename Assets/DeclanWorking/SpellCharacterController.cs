using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCharacterController : MonoBehaviour
{
    CharacterController spell;
   // [HideInInspector]
    public PlayerController PlayerCon;
    public GameObject Player;
    

    private void Start()
    {
        //print(transform.position);
        spell = GetComponent<CharacterController>();
        Player = GameObject.Find("Player 1");
        print("start: " + transform.position);
        transform.position = Player.transform.position;
    }
    private void Update()
    {
        Vector3 movDir = new Vector3(PlayerCon.moveDirection.x, 0.0f, PlayerCon.moveDirection.z);
        //print("update: " + transform.position +" "+ "movdir: " + movDir);
        print("before move" + transform.position);
        spell.Move(movDir * Time.deltaTime);
        print("After move" + transform.position);
    }

}


