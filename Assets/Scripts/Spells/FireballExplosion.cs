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
		Fireball fireball = transform.parent.gameObject.GetComponent<Fireball>();
		fireball.aging = false;

		if (other.CompareTag("Meltable"))
		{
			WaterWheel waterWheel = other.gameObject.GetComponent<WaterWheel>();
			if (waterWheel)
				waterWheel.isFrozen = false;
		}
		if (other.CompareTag("Lightable"))
		{
			Sconce sconce = other.gameObject.GetComponent<Sconce>();
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
			if (spellbook)
				spellbook.burning = true;
		}

		if (other.CompareTag("Player"))
		{
			PlayerController playerController = other.GetComponent<PlayerController>();
			if (playerController && playerController != fireball.caster)
				playerController.isDead = true;
		}
		
		Destroy(transform.parent.gameObject, explosionTime);
	}
}
