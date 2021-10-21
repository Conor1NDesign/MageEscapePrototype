using UnityEngine;

public class TornadoGust : MonoBehaviour
{
    public float HieghtOfHeavyObject = 1;
    [HideInInspector]
    public PlayerController caster;
    [HideInInspector]
    GameObject currentlyLifting;
    public GameObject lockPos;
    CharacterController cc;
    SpellCharacterController scc;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        scc = GetComponent<SpellCharacterController>();
    }


    float counter = 0;
    public float maxAirTime = 0.5f;
    private void Update()
    {
        if (cc.isGrounded)
        {

            counter = 0.0f;
        }
        else
        {
            counter += Time.deltaTime;
            if (counter > maxAirTime)
            {
                caster.tornadoActive = false;
                caster.tornado = null;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Heavy Object") || other.CompareTag("MM"))
        {
            if (currentlyLifting == null && other.name != "MirrorCollider")
            {

                other.attachedRigidbody.isKinematic = true;
                currentlyLifting = other.gameObject;
                other.transform.position = lockPos.transform.position;
            }

        }
    }
    private void OnDestroy()
    {
        scc.playerCasting.playerState = PlayerController.PlayerStates.Idle;
        if (currentlyLifting != null)
        {
            currentlyLifting.GetComponent<Rigidbody>().isKinematic = false;

            currentlyLifting = null;
            //currentlyLifting.transform.parent = null;
        }
    }


}
