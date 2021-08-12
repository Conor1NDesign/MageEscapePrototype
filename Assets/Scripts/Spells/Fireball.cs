using UnityEngine;

public class Fireball : MonoBehaviour
{
	public GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Spellbook"))
        {
            explosion.SetActive(true);
        }
    }
}
