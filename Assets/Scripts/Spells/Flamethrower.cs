using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    [HideInInspector]
    public PlayerController playerCasting;
    [HideInInspector]
    public IceWall iceWall;

    private FrozonMode frozenMode;

    private void Start()
    {
        frozenMode = GetComponentInChildren<FrozonMode>();
    }
    RaycastHit RayHit;
    public LayerMask ignore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meltable"))
        {

            if (Physics.Linecast(transform.position, other.transform.position, out RayHit, ~ignore))
            {
                if (RayHit.collider.CompareTag("Meltable"))
                {

                    IceWall iceWall = other.gameObject.GetComponent<IceWall>();
                    if (iceWall)
                    {
                        iceWall.melting = true;
                        this.iceWall = iceWall;
                    }
                    WaterWheel waterWheel = other.gameObject.GetComponent<WaterWheel>();
                    if (waterWheel)
                        waterWheel.isFrozen = false;
                }
            }
        }
        if (other.CompareTag("Lightable"))
        {
            if (Physics.Linecast(transform.position, other.transform.position, out RayHit, ~ignore))
            {
                if (RayHit.collider.CompareTag("Lightable"))
                {
                    Sconce sconce = other.gameObject.GetComponent<Sconce>();
                    if (sconce)
                        sconce.isActivated = true;
                }
            }
        }

        if (other.CompareTag("Water"))
        {

            if (Physics.Linecast(transform.position, other.transform.position, out RayHit, ~ignore))
            {
                if (RayHit.collider.CompareTag("Water"))
                {

            frozenMode.MarchTheCubes(false);
            print("Defrost");
                }
            }
        }

        SpinningBlade sb = other.GetComponent<SpinningBlade>();
        if (sb != null)
        {
            sb.isSlowed = false;
        }

        if (other.CompareTag("Spellbook"))
        {
            SpellbookController spellbook = other.gameObject.GetComponent<SpellbookController>();
            if (spellbook && spellbook.playerHolding != playerCasting)
                spellbook.burning = true;
        }

		if (other.CompareTag("Player"))
		{
			PlayerController playerController = other.GetComponent<PlayerController>();
			if (playerController)
				playerController.SetOnFire(true);
		}
    }

    private void OnTriggerExit(Collider other)
    {
        IceWall iceWall = other.gameObject.GetComponent<IceWall>();
        if (iceWall)
        {
            iceWall.melting = false;
            this.iceWall = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.DrawLine(transform.position, other.transform.position);
    }
}
