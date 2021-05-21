using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /*
    * * * * * * * * * * TO DO * * * * * * * * * *
    * - Gravity works, but could use adjustments
    * 
    * - Implement and update conditions for player
    *   death.
    *   
    * - Implement conditions for Respawning and
    *   Checkpoint assignment.
    *   
    * - Implement PlayerState transitions and 
    *   values.
    * * * * * * * * * * * * * * * * * * * * * * *
    * * * * * * OTHER SCRIPTS/OBJECTS * * * * * *
    * - Create and implement spellbooks.
    *       - Picking them up.
    *       - Throwing them. 
    *       - Casting spells. 
    * * * * * * * * * * * * * * * * * * * * * * *
    */

    //Enum declaration for the player's current action.
    public enum PlayerCurrentState
    {
        Idle,
        Moving,
        Falling,
        Floating,
        Casting,
        Dead,
        Respawning
    };

    //Enum declaration for the player's current spellbook element (or lack thereof, if they have no book currently)
    public enum PlayerCurrentElement
    {
        None,
        Fire,
        Frost,
        Earth,
        Wind
    };


    [Header("PLAYER INDEX - 0 for P1, 1 for P2")]
    public int playerIndex = 0;

    [Header("Current Player State")]
    public PlayerCurrentState playerState = PlayerCurrentState.Idle;

    [Header("Character Control Variables")]
    private float currentMoveSpeed; //Private value for current movement speed, is changed based on player state.
    public float defaultMoveSpeed;
    public float airborneMoveSpeed;
    public float rotateSpeed;

    //Variable for the CharacterController component on the object the script is attached to.
    private CharacterController controller;

    //Variables for recieving Player Inputs, and determining a movement direction vector from them.
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    //Variable for the camera used in each level.
    private Camera levelCamera;

    private void Awake()
    {
        //Finds the main camera on the level, used for movement and rotation directions.
        levelCamera = Camera.main;

        //Finds the Character Controller component on the object this script is attached to.
        controller = GetComponent<CharacterController>();
    }

    public int GetPlayerIndex()
    {
        //Returns the playerIndex value assigned in the inspector when called. Currently used to prevent multiple input devices controlling the same character.
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        //Called by PlayerInputHandler to assign a direction for the player to move and/or face.
        inputVector = direction;
    }


    void Update()
    {
        //Sets a moveDirection variable using the X and Y values of the inputVector and translating them to the X and Z values of a Vector3.
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        //Adjusts the moveDirection based on the angle of the Main Camera object.
        moveDirection = Quaternion.Euler(0, levelCamera.gameObject.transform.eulerAngles.y, 0) * moveDirection;
        //Lastly, multiplies moveDirection by moveSpeed to get a final value for the Controller's Move() method.
        moveDirection *= currentMoveSpeed;

        //Translates moveDirection into a Quaternion and assigns it to the rotation variable.
        var rotationVector = new Vector3(inputVector.x, 0, inputVector.y);
        //Adjusts the rotationVector based on the main camera position.
        rotationVector = Quaternion.Euler(0, levelCamera.gameObject.transform.eulerAngles.y, 0) * rotationVector;
        //Lastly, multiplies rotationVector by currentMoveSpeed to get a final value for the RotateTowardsMovement() method.
        rotationVector *= currentMoveSpeed;
        var rotation = Quaternion.LookRotation(rotationVector);

        //Applies gravitational force to the player.
        moveDirection += Physics.gravity;
        
        //Calls the Move() method on the CharacterController using the moveDirection value.
        controller.Move(moveDirection * Time.deltaTime);

        //Checks if there is still input coming from the player. This prevents the mesh from rotating back to Y = 0 when there's no input.
        if (moveDirection != new Vector3(0 , moveDirection.y, 0))
        {
            RotateTowardsMovement(rotation);
        }


        //PLAYER STATE CHECKS//

        //Checks if the Player's state is Idle or Moving, and adjusts their movement speed accordingly.
        if (playerState == PlayerCurrentState.Idle || playerState == PlayerCurrentState.Moving)
            currentMoveSpeed = defaultMoveSpeed;

        //Checks if the Player's state is Falling or Floating, and adjusts their movement speed accordingly.
        if (playerState == PlayerCurrentState.Falling || playerState == PlayerCurrentState.Floating)
            currentMoveSpeed = airborneMoveSpeed;

        //Checks if the Player's state is Dead, Respawning, or Casting, and adjusts their movement speed accordingly.
        if (playerState == PlayerCurrentState.Dead || playerState == PlayerCurrentState.Respawning || playerState == PlayerCurrentState.Casting)
            currentMoveSpeed = 0;

        //PLAYER STATE CHECKS END//
    }

    public void RotateTowardsMovement(Quaternion rotation)
    {
        //Rotates the Player to face the value of the rotation variable.
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, rotateSpeed);
    }
}


