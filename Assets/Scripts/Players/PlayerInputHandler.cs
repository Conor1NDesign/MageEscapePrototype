using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    //Variables grabbed on Awake that allow input to be recieved by the script, and send actions and instructions to their assigned player object.
    private PlayerInput playerInput;
    private PlayerController playerController;

    private void Awake()
    {
        //Gets the Player Input component on the object this script is attatched to.
        playerInput = GetComponent<PlayerInput>();
        //Gets the Player Index from playerInput.
        var index = playerInput.playerIndex;

        //Finds all objects with PlayerControllers, and then assigns the object with this script to the one that shares an identical playerIndex.
        //This prevents multiple players from somehow controlling the same player.
        var playerControllers = FindObjectsOfType<PlayerController>();
        playerController = playerControllers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    public void OnMove(CallbackContext context)
    {
        //Sends the Vector2 of the gamepad input to the playerController so that it can move the player.
        if (playerController != null) //All player input methods need to check if playerController is NOT null otherwise Input System spits out a bunch of errors.
        {
            playerController.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    // Throws the player's spellbook
    public void OnThrow(CallbackContext context)
    {
        if (playerController) //All player input methods need to check if playerController is NOT null otherwise Input System spits out a bunch of errors.
        {
            if (context.performed)
                playerController.InteractWithSpellbook();
        }
    }
}
