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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meltable"))
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
        if (other.CompareTag("Lightable"))
        {
            Scone sconce = other.gameObject.GetComponent<Scone>();
            if (sconce)
                sconce.isActivated = true;
        }
        
        if (other.CompareTag("Water"))
        {
            frozenMode.MarchTheCubes(false);
            print("Defrost");
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
}
