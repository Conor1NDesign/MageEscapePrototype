using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
	public float explosionTime;

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Lightable"))
        {
            other.gameObject.GetComponent<Scone>().isActivated = true;
        }

		Destroy(transform.root.gameObject, explosionTime);
	}
}
