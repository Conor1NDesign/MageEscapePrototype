using UnityEngine;

public class Fireball : MonoBehaviour
{
	[Tooltip("Disabled explosion child object with the FireballExplosion script attached, for EXPLOSIONS!")]
	public GameObject explosion;
	[Tooltip("The maximum time the fireball can fly for")]
	public float maxTime;
	private float age = 0.0f;

	void Update()
	{
		age += Time.deltaTime;
		if (age > maxTime)
			Destroy(gameObject);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Spellbook"))
        {
            explosion.SetActive(true);
        }
    }
}
