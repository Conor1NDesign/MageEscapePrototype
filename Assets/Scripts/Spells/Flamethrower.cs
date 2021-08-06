using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private void Update()
    {
        print("FROOOSHUPDATE");

    }
    private void OnTriggerEnter(Collider other)
    {
        print("FROOOSH");
        if (!other.CompareTag("Spellbook"))
        {

            print("FROOOSH");
            if (other.CompareTag("Meltable"))
            {
                other.gameObject.GetComponent<IceWall>().melted = true;
            }
        }
    }
}
