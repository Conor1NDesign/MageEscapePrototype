using UnityEngine;

public class Fireball : MonoBehaviour
{
	[Tooltip("Disabled explosion child object with the FireballExplosion script attached, for EXPLOSIONS!")]
	public GameObject explosion;
	[Tooltip("The maximum time the fireball can fly for")]
	public float maxTime;
	private float age = 0.0f;
	[HideInInspector]
	public bool aging = false;

	void Update()
	{
		if (aging)
		{
			age += Time.deltaTime;
			if (age > maxTime)
				Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Spellbook"))
		{
			explosion.SetActive(true);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}
