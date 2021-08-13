using UnityEngine;

public class Fireball : MonoBehaviour
{
	[Tooltip("Disabled explosion child object with the FireballExplosion script attached, for EXPLOSIONS!")]
	public GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Spellbook"))
        {
            explosion.SetActive(true);
        }
    }
}
