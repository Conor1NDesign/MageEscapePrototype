using UnityEngine;

public class Fireball : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Spellbook"))
        {
            // Do fiery stuff
            Debug.Log("boom");
            Destroy(gameObject);
        }
    }
}
