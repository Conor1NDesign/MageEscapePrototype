using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
	/*
	* * * * * * * * * * TO DO * * * * * * * * * *
	* - Implement and update conditions for player
	*   death.
	*       - Falling implemented.
	*   
	* - Implement conditions for Checkpoint 
	*   assignment.
	*   
	* - Implement PlayerState transitions and 
	*   values.
	*       - Basic states implemented.
	* * * * * * * * * * * * * * * * * * * * * * *
	* * * * * * OTHER SCRIPTS/OBJECTS * * * * * *
	* - Create and implement spellbooks.
	*       - Picking them up.
	*       - Throwing them. 
	*       - Casting spells. 
	* * * * * * * * * * * * * * * * * * * * * * *
	*/

	//Enum declaration for the player's current action.
	public enum PlayerStates
	{
		Idle,
		Moving,
		Falling,
		Floating,
		Casting,
		Dead,
		Respawning,
		Throwing
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

	public enum CastingType
	{
		None,
		Quick,
		Hard
	};


	[Header("PLAYER INDEX")]
	[Tooltip("This Player's Index number. Player 1 should have index 0, and Player 2 should have index 1.")]
	public int playerIndex = 0;

	[Header("Current Player State")]
	[Tooltip("The current state of the player, determines what actions they can take and adjusts some of their variables.")]
	public PlayerStates playerState = PlayerStates.Idle;
	[Tooltip("The current spellbook element of the player")]
	public PlayerCurrentElement playerElement = PlayerCurrentElement.None;
	[Tooltip("The current spellbook the player is holding")]
	public GameObject spellbook = null;
	[HideInInspector]
	public GameObject nearbySpellbook = null; // Nearby spellbook, to be equipped on a button press

	[Header("Character Control Variables")]
	[Tooltip("The default movement speed for the player. This is used while they are grounded.")]
	public float defaultMoveSpeed;
	[Tooltip("The movement speed for the player while they are airborne, either falling or floating due to a wind spell.")]
	public float airborneMoveSpeed;
	private float currentMoveSpeed; //Private value for current movement speed, is changed based on player state.
	[Tooltip("The speed at which the player rotates towards the direction they are moving. Values higher than 5 aren't really noticeable.")]
	public float rotateSpeed;
	[Tooltip("The speed at which the player rotates when casting.")]
	public float castingRotationSpeed;
	private float currentRotateSpeed; //Private value for current rotation speed, is changed based on player state.
	[Tooltip("The default strength of gravity, be mindful that the value of Gravity Ramp Up is added to this each frame that the player is falling.")]
	public float defaultGravityMultiplier;
	[Tooltip("The maximum strength of gravity. For example: A value of 2 would mean that that the strength can go up to double the Unity default.")]
	public float maxGravityMultiplier = 2;
	[Tooltip("The value that gravity increases by each frame that a player is falling. Values above 0.02 can end up looking really goofy, beware.")]
	public float gravityRampUp;
	[HideInInspector]
	public float gravityMultiplier;
	[Tooltip("The player's max strength with throwing spellbooks")]
	public float throwStrength;
	[Tooltip("The speed at which the throw strength grows to that maximum")]
	public float throwStrengthGrowth = 1.0f;
	private float currentThrowStrength;

	[Header("Respawning Settings")]
	[Tooltip("The amount of time (in seconds) it takes to respawn the player when they die.")]
	public int respawnTime = 3;
	[Tooltip("The current location that the player will respawn at, this value should only ever be a Starting Point or a Checkpoint's Transform.")]
	public Transform currentSpawnPoint;

	[Header("Checking Player State")]
	[Tooltip("Used to check if the player is currently under the effects of a wind spell. Should be false if they are not.")]
	public bool isFloating;
	[Tooltip("Used to check if the player is currently dead. Should be returned to false after they've respawned.")]
	public bool isDead;
	private bool isRespawning; //A bool used privately within this script to ensure that the respawn coroutine isn't called multiple times.
	[HideInInspector]
	public bool isHardCasting;

	[Header("Spell Prefabs")]
	public GameObject flamethrowerPrefab;
	public GameObject fireballPrefab;
	public GameObject gustPrefab;
	public GameObject tornadoTargetPrefab;
	public GameObject tornadoLiftPrefab;
	public GameObject earthPlatformPrefab;
	public GameObject boulderTargetPrefab;
	public GameObject boulderPrefab;
	public GameObject frostWavePrefab;
	public GameObject frostBeamPrefab;

	[HideInInspector]
	public bool rotationLockedBySpell = false;
	[HideInInspector]
	public bool tornadoActive = false;
	[HideInInspector]
	public GameObject tornado;
	[HideInInspector]
	public GameObject boulder;
	[Tooltip("The force at which the fireball is launched")]
	public float fireballForce;

	[Tooltip("The force is with you (actually this is an unused variable)")]
	public float tornadoForce;
	public float tornadoTime;

	[Tooltip("The distance forward that the earth platform is placed")]
	public float earthPlatformForwardness = 2.0f;

	[Header("Miscellaneous Variables")]
	[Tooltip("The player's mesh.")]
	public SkinnedMeshRenderer playerMesh;
	[Tooltip("The player's spellbook equip point")]
	public Transform spellbookEquipPoint;
	[Tooltip("The player's spell attach point")]
	public Transform spellAttachPoint;
	[HideInInspector]
	public GameObject attachedSpell;
	[HideInInspector]
	public CastingType castType = CastingType.None;
	[HideInInspector]
	public GameObject earthPlatform;
	[Tooltip("The camera's pivot (shared for chaos)")]
	public Transform cameraPivot;
	[Tooltip("Camera rotation speed, limits how fast the camera will rotate")]
	public float cameraRotateSpeed;
	[Tooltip("The minimum time between quick spell casts")]
	public float quickCastCooldown;
	[Tooltip("The minimum time between hard spell casts")]
	public float hardCastCooldown;
	[HideInInspector]
	public float currentCooldown;

	//Variable for the CharacterController component on the object the script is attached to.
	private CharacterController controller;

	//Variables for recieving Player Inputs, and determining a movement direction vector from them.
	[HideInInspector]
	public Vector3 moveDirection = Vector3.zero;
	private Vector2 inputVector = Vector2.zero;
	private Vector2 cameraInputVector = Vector2.zero;

	//Variable for the camera used in each level.
	private Camera levelCamera;
	[HideInInspector]
	public bool useGravity = true;



	public SpellSounds AudioManager;

	public Animator animator;
	GameObject interactable;

	public string inputDevice;

	private void Awake()
	{
		//Finds the main camera on the level, used for movement and rotation directions.
		levelCamera = Camera.main;

		//Finds the Character Controller component on the object this script is attached to.
		controller = GetComponent<CharacterController>();

		//Finds the spell audio controller
		AudioManager = FindObjectOfType<SpellSounds>();

		if (AudioManager == null)
		{
			Debug.LogError("OI MATE ADD A SpellSounds Script to GameManager, don't come bitching to me ~Declan");
		}
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

	public void SetCameraInputVector(Vector2 direction)
	{
		// Called by PlayerInputHandler to assign a direction for the camera to rotate
		cameraInputVector = direction;
	}


	void Update()
	{
		currentCooldown -= Time.deltaTime;
		//Debug.Log("Player " + playerIndex + " is currently:" + playerState);
		//Debug.Log("Player " + playerIndex + "'s movementVector is: " + moveDirection);

		// CAMERA ROTATION //

		cameraPivot.Rotate(new Vector3(0, cameraInputVector.x * cameraRotateSpeed, 0));

		// CAMERA ROTATION END //

		//MOVEMENT AND ROTATION//

		//Sets a moveDirection variable using the X and Y values of the inputVector and translating them to the X and Z values of a Vector3.
		moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

		//Adjusts the moveDirection based on the angle of the Main Camera object.
		moveDirection = Quaternion.Euler(0, levelCamera.gameObject.transform.eulerAngles.y, 0) * moveDirection;
		//Lastly, multiplies moveDirection by moveSpeed to get a final value for the Controller's Move() method.
		if (!(tornadoActive || playerState == PlayerStates.Throwing))
		{

			moveDirection *= currentMoveSpeed;
		}
		else
		{
			moveDirection *= defaultMoveSpeed;
		}

		//Translates moveDirection into a Quaternion and assigns it to the rotation variable.
		var rotationVector = new Vector3(inputVector.x, 0, inputVector.y);
		//Adjusts the rotationVector based on the main camera position.
		rotationVector = Quaternion.Euler(0, levelCamera.gameObject.transform.eulerAngles.y, 0) * rotationVector;
		//Lastly, multiplies rotationVector by currentMoveSpeed to get a final value for the RotateTowardsMovement() method.
		rotationVector *= defaultMoveSpeed;
		Quaternion rotation = Quaternion.Euler(0, 0, 0);
		if (rotationVector != Vector3.zero)
			rotation = Quaternion.LookRotation(rotationVector);

		//Applies gravitational force to the player.
		if (useGravity)
		{
			moveDirection += Physics.gravity * gravityMultiplier;
		}

		//Calls the Move() method on the CharacterController using the moveDirection value.
		//controller.Move(moveDirection * Time.deltaTime);
		if (transform.parent == null && !(tornadoActive || playerState == PlayerStates.Throwing))
		{
			Move(moveDirection);
		}


		//Checks if there is still input coming from the player. This prevents the mesh from rotating back to Y = 0 when there's no input.
		if (inputVector != new Vector2(0, 0))
		{
			RotateTowardsMovement(rotation);
		}

		//MOVEMENT AND ROTATION END//

		//PLAYER STATE CHANGES//

		//Checks if the player is grounded, has some movement input, and is not dead, before returning that they are 'Moving'.
		if (controller.isGrounded && moveDirection != new Vector3(0, moveDirection.y, 0) && !isDead && playerState != PlayerStates.Casting && playerState != PlayerStates.Throwing)
		{
			playerState = PlayerStates.Moving;
		}

		//Checks if the player is grounded, has NO movement input, and is not dead, before returning that they are 'Idle'.
		if (controller.isGrounded && moveDirection == new Vector3(0, moveDirection.y, 0) && !isDead && playerState != PlayerStates.Casting && playerState != PlayerStates.Throwing)
		{
			playerState = PlayerStates.Idle;
		}

		//Checks if the player is not grounded, is unaffected by a wind spell, and is not dead, before returning that they are 'Falling'.
		if (!controller.isGrounded && !isFloating && !isDead)
		{
			if (playerState == PlayerStates.Casting)
			{
				Destroy(attachedSpell);
				attachedSpell = null;
				Destroy(tornado);
				tornado = null;
			}

			playerState = PlayerStates.Falling;
		}

		//Checks if the player is not grounded, is currently influenced by a wind spell, and is not dead, before returning that they are 'Floating'.
		if (!controller.isGrounded && isFloating && !isDead)
		{
			if (playerState == PlayerStates.Casting)
			{
				Destroy(attachedSpell);
				attachedSpell = null;
				Destroy(tornado);
				tornado = null;
			}

			playerState = PlayerStates.Floating;
		}

		//Checks if the player has died in the last frame, and has not already had their respawn process started.
		if (isDead && !isRespawning)
		{
			playerState = PlayerStates.Dead;
		}

		//Checks if the player is dead and has started their respawn process.
		if (isDead && isRespawning)
		{
			playerState = PlayerStates.Respawning;
			gameObject.transform.position = currentSpawnPoint.position;
		}


		//PLAYER STATE CHANGES END//

		//PLAYER STATE CHECKS//

		//Checks if the Player's state is 'Idle'.
		if (playerState == PlayerStates.Idle)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = defaultMoveSpeed;
			currentRotateSpeed = rotateSpeed;
			gravityMultiplier = defaultGravityMultiplier;
		}

		//Checks if the Player's state is 'Moving'.
		if (playerState == PlayerStates.Moving)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = defaultMoveSpeed;
			currentRotateSpeed = rotateSpeed;
			gravityMultiplier = defaultGravityMultiplier;
		}

		//Checks if the Player's state is 'Falling'.
		if (playerState == PlayerStates.Falling)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = airborneMoveSpeed;
			currentRotateSpeed = rotateSpeed;

			//A statement to make sure that gravity can't go beyond a maximum value set in the inspector. This is to prevent gravity from reaching an infinite value.
			if (gravityMultiplier < maxGravityMultiplier)
			{
				gravityMultiplier += gravityRampUp;
			}
		}

		//Checks if the Player's state is 'Floating'.
		if (playerState == PlayerStates.Floating)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = airborneMoveSpeed;
			currentRotateSpeed = rotateSpeed;
			gravityMultiplier = 0;
		}

		//Checks if the Player's state is 'Dead'.
		if (playerState == PlayerStates.Dead)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = 0;
			currentRotateSpeed = 0;
			gravityMultiplier = 0;
			// Drop spellbook on death
			DropSpellbook();
			StartCoroutine(RespawnPlayer());
		}

		//Checks if the Player's state is 'Respawning'.
		if (playerState == PlayerStates.Respawning)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = 0;
			currentRotateSpeed = 0;
		}

		//Checks if the Player's state is 'Casting'.
		if (playerState == PlayerStates.Casting)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = 0;
			currentRotateSpeed = rotationLockedBySpell ? 0 : castingRotationSpeed;
		}

		//Checks if the player is throwing their book
		if (playerState == PlayerStates.Throwing)
		{
			animator.SetInteger("State", (int)playerState);
			currentMoveSpeed = 0;
			currentRotateSpeed = rotateSpeed;
			currentThrowStrength += Time.deltaTime * throwStrengthGrowth;
			if (currentThrowStrength > throwStrength)
				currentThrowStrength = throwStrength;
		}

		//PLAYER STATE CHECKS END//
	}

	public void Move(Vector3 movDir)
	{
		controller.Move(movDir * Time.deltaTime);
	}
	//Coroutine for respawning the player if they somehow die.
	public IEnumerator RespawnPlayer()
	{
		playerMesh.enabled = false;
		isRespawning = true;
		yield return new WaitForSeconds(respawnTime);
		isDead = false;
		isRespawning = false;
		playerMesh.enabled = true;
	}

	public void Interact(bool active)
	{
		if (interactable != null)
		{
			if (active)
			{
				interactable.GetComponent<Lever>().isActive = true;
				print("DOWN DOWN");
			}
			else
			{
				interactable.GetComponent<Lever>().isActive = false;
				print("UP UP");
			}
		}
	}


	public void RotateTowardsMovement(Quaternion rotation)
	{
		//Rotates the Player to face the value of the rotation variable.
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, rotation, currentRotateSpeed);
	}

	// Throws the player's current spellbook
	public void InteractWithSpellbook(bool endThrow)
	{
		if (playerState == PlayerStates.Casting)
			return;

		if (spellbook)
		{
			if (endThrow && playerState == PlayerStates.Throwing)
			{
				playerState = PlayerStates.Idle;
				animator.speed = 1;
				// Throw a spellbook if you have one equipped
				Rigidbody spellbookRB = spellbook.GetComponent<Rigidbody>();
				DropSpellbook();

				spellbookRB.AddForce(transform.forward * currentThrowStrength, ForceMode.Impulse);
				//spellbookRB.AddForce(transform.up * (currentThrowStrength / 4), ForceMode.Impulse);
			} else if (!endThrow) {
				playerState = PlayerStates.Throwing;
				currentThrowStrength = 0.0f;
			}
		}
		else if (nearbySpellbook)
		{
			if (nearbySpellbook.transform.parent)
			{
				PlayerController otherPlayer = nearbySpellbook.transform.parent.GetComponent<PlayerController>();
				otherPlayer.DropSpellbook();
			}

			// Equip a spellbook if there's one nearby
			spellbook = nearbySpellbook;

			playerElement = spellbook.GetComponent<SpellbookController>().element;

			spellbook.transform.parent = spellbookEquipPoint;
			spellbook.transform.position = spellbookEquipPoint.position;
			spellbook.transform.rotation = spellbookEquipPoint.rotation;
			spellbook.GetComponent<Rigidbody>().isKinematic = true;
			spellbook.GetComponent<SpellbookController>().playerHolding = this;
		}
	}

	// Sets the nearby spellbook when you collide with it
	private void OnTriggerEnter(Collider other)
	{
		Transform collidedBook = other.transform.parent;

		if (collidedBook && collidedBook.CompareTag("Spellbook"))
		{
			nearbySpellbook = collidedBook.gameObject;
		}
		if (other.CompareTag("Interactable"))
		{
			interactable = other.gameObject;
		}
	}

	// Clears the nearby spellbook when you leave it
	// yes this will leave you with no nearby spellbook if you move out of one while still in another
	private void OnTriggerExit(Collider other)
	{
		Transform collidedBook = other.transform.parent;

		if (collidedBook && collidedBook.CompareTag("Spellbook"))
		{
			nearbySpellbook = null;
		}
	}

	public void AttachSpell(GameObject spell)
	{
		if (attachedSpell != null)
			return;

		spell.transform.parent = spellAttachPoint;
		spell.transform.position = spellAttachPoint.position;
		spell.transform.rotation = spellAttachPoint.rotation;
		attachedSpell = spell;
	}

	public GameObject ClearSpell()
	{
		if (attachedSpell)
		{
			GameObject spell = attachedSpell;
			attachedSpell = null;
			spell.transform.parent = null;
			return spell;
		}
		return null;
	}

	public void DropSpellbook()
	{
		if (spellbook)
		{
			if (playerState == PlayerStates.Casting)
			{
				if (isHardCasting)
					SpellFunctions.EndHardCast(this);
				else
					SpellFunctions.EndQuickCast(this);
			}

			if (playerState == PlayerStates.Throwing)
				playerState = PlayerStates.Idle;

			// Drop spellbook on death
			spellbook.transform.parent = null;
			spellbook.GetComponent<Rigidbody>().isKinematic = false;
			spellbook.GetComponent<SpellbookController>().playerHolding = null;

			playerElement = PlayerCurrentElement.None;
			spellbook = null;
		}
	}
}


