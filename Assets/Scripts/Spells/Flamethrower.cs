using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private FrozonMode frozenMode;

    private void Start()
    {
        frozenMode = GetComponent<FrozonMode>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Spellbook"))
        {
            if (other.CompareTag("Meltable"))
            {
                if (other.gameObject.GetComponent<IceWall>() != null)
                {
                    other.gameObject.GetComponent<IceWall>().melted = true;
                }
                if (other.gameObject.GetComponent<WaterWheel>() != null)
                {
                    other.gameObject.GetComponent<WaterWheel>().isFrozen = false;
                }
            }

            if (other.CompareTag("Water"))
            {
                frozenMode.MarchTheCubes(true);
            }
        }
    }
}
