using UnityEngine;

public class AntiMagicBarrier : MonoBehaviour
{

	PlayerController[] casters;

	void Start()
	{
		casters = FindObjectsOfType<PlayerController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Spellbook"))
		{
			SpellbookController spellbook = other.GetComponent<SpellbookController>();
			if (spellbook)
				spellbook.Respawn();
		}

		if (other.gameObject.layer == 8)
		{
			PlayerController caster = other.GetComponent<SpellCharacterController>().playerCasting;
			caster.tornadoActive = false;
			caster.tornado = null;
			Destroy(other.gameObject);
		}
	}
}
