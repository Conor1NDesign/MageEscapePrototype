using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    //Variables grabbed on Awake that allow input to be recieved by the script, and send actions and instructions to their assigned player object.
    private PlayerInput playerInput;
    private PlayerController playerController;
    private GameObject gameManager;
    private TutorialTextAnCamera ttac;
    private bool inTutorial = false;
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
        playerController.inputDevice = playerInput.currentControlScheme;

        if (SceneManager.GetActiveScene().name == "00 - Tutorial Level")
        {
            inTutorial = true;
        }

        gameManager = GameObject.Find("GameManager");
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
            if (inTutorial)
            {
                if (gameManager.GetComponent<TutorialManager>().ttac == null)
                {
                    if (context.performed)
                        playerController.InteractWithSpellbook(false);
                    else if (context.canceled)
                        playerController.animator.speed = 1;
                }
            }
            else
            {
                if (context.performed)
                    playerController.InteractWithSpellbook(false);
                else if (context.canceled)
                    playerController.animator.speed = 1;
            }

        }
    }

    public void OnInteract(CallbackContext context)
    {
        if (playerController) //All player input methods need to check if playerController is NOT null otherwise Input System spits out a bunch of errors.
        {
            if (inTutorial)
            {
                if (context.performed)
                {
                    if (gameManager.GetComponent<TutorialManager>() != null)
                    {
                        if (gameManager.GetComponent<TutorialManager>().ttac != null)
                        {
                            if (ttac == null)
                            {
                                ttac = gameManager.GetComponent<TutorialManager>().ttac;
                            }


                            if (ttac != false)
                            {
                                ttac.CurrentUIText = ttac.nextText();
                                if (ttac.CurrentUIText != "")
                                {
                                    ttac.text.text = ttac.CurrentUIText;
                                    ttac.CheckIfCamNeedsToBeChanged();
                                }
                                else
                                {
                                    ttac.EndSequence();
                                    ttac = null;
                                }
                            }

                        }
                    }
                }
            }

            if (context.performed)
            {
                playerController.Interact(true);
            }
            else
            {
                playerController.Interact(false);
            }
        }
    }


    public void OnCameraMove(CallbackContext context)
    {
        if (playerController)
        {
            playerController.SetCameraInputVector(context.ReadValue<Vector2>());
        }
    }

    public void OnQuickCast(CallbackContext context)
    {
        if (playerController &&
            playerController.playerElement != PlayerController.PlayerCurrentElement.None)
        {
            if (context.performed &&
                (int)playerController.playerState <= 1)
            {
                SpellFunctions.StartQuickCast(playerController);
                playerController.playerState = PlayerController.PlayerStates.Casting;
                playerController.castType = PlayerController.CastingType.Quick;
            }
            else if (context.canceled &&
                playerController.castType == PlayerController.CastingType.Quick)
            {
                SpellFunctions.EndQuickCast(playerController);
                playerController.playerState = PlayerController.PlayerStates.Idle;
                playerController.castType = PlayerController.CastingType.None;
            }
        }
    }

    public void OnHardCast(CallbackContext context)
    {
        if (playerController &&
            playerController.playerElement != PlayerController.PlayerCurrentElement.None)
        {
            if (context.performed &&
                ((int)playerController.playerState <= 1 ||
                playerController.playerElement == PlayerController.PlayerCurrentElement.Wind && playerController.playerState == PlayerController.PlayerStates.Casting))
            {
                SpellFunctions.StartHardCast(playerController);
                playerController.playerState = PlayerController.PlayerStates.Casting;
                playerController.castType = PlayerController.CastingType.Hard;
            }
            else if (context.canceled &&
                playerController.castType == PlayerController.CastingType.Hard)
            {
                SpellFunctions.EndHardCast(playerController);
                if (playerController.playerElement != PlayerController.PlayerCurrentElement.Wind)
                    playerController.playerState = PlayerController.PlayerStates.Idle;
                playerController.castType = PlayerController.CastingType.None;
            }
        }
    }

    public void OnPause(CallbackContext context)
    {
        if (context.performed)
        {
            if (playerController) //All player input methods need to check if playerController is NOT null otherwise Input System spits out a bunch of errors.
            {
                FindObjectOfType<PauseMenu>().Pause();
            }
        }
    }

	public void OnRespawnPlayer(CallbackContext context) {
		if (playerController) {
			if (context.performed)
			{
				playerController.currentManualRespawnTime = playerController.manualRespawnTime;
				playerController.manuallyRespawning = true;
			}
			else if (context.canceled)
			{
				playerController.manuallyRespawning = false;
			}
		}
	}

	public void OnRespawnBooks(CallbackContext context) {
		if (context.performed && playerController)
		{

		}
	}
}
