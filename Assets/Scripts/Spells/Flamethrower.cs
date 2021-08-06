using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Spellbook"))
        {
            if (other.CompareTag("Meltable"))
            {
            print("FROOOSH");
                other.gameObject.GetComponent<IceWall>().melted = true;
            }
        }
    }
}
