using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
	[Tooltip("The amount of time the explosion is active for")]
	public float explosionTime;

    private FrozonMode frozenMode;

    private void Start()
    {
        frozenMode = GetComponentInChildren<FrozonMode>();
    }

    void OnTriggerEnter(Collider other)
	{
		transform.root.gameObject.GetComponent<Fireball>().aging = false;
		if (other.CompareTag("Meltable"))
        {
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
			Debug.Log("nyaa");
            SpellbookController spellbook = other.gameObject.GetComponent<SpellbookController>();
            if (spellbook)
                spellbook.burning = true;
        }

		Destroy(transform.root.gameObject, explosionTime);
	}
}
