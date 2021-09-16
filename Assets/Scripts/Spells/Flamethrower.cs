﻿using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private FrozonMode frozenMode;

    private void Start()
    {
        frozenMode = GetComponentInChildren<FrozonMode>();
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
            if (other.CompareTag("Lightable"))
            {
                if (other.gameObject.GetComponent<Scone>() != null)
                {
                    other.gameObject.GetComponent<Scone>().isActivated = true;
                }
            }
            
            if (other.CompareTag("Water"))
            {
                frozenMode.MarchTheCubes(false);
                print("Defrost");
            }

            SpinningBlade sb = other.GetComponent<SpinningBlade>();
            if (sb != null)
            {
                sb.isSlowed = false;
            }
        }
    }
}
