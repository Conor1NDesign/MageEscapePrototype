using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
	[Tooltip("The amount of time the explosion is active for")]
	public float explosionTime;

    void OnTriggerEnter(Collider other)
	{
		transform.root.gameObject.GetComponent<Fireball>().aging = false;
		if (other.gameObject.CompareTag("Lightable"))
        {
            other.gameObject.GetComponent<Scone>().isActivated = true;
        }
		if (other.gameObject.CompareTag("Meltable"))
		{
			other.gameObject.GetComponent<WaterWheel>().isFrozen = false;
		}

		Destroy(transform.root.gameObject, explosionTime);
	}
}
