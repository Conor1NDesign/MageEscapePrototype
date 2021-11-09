using UnityEngine;

public class WaterWheel : Interactable
{
    public GameObject wheel;
    public Vector3 wheelRotation = new Vector3(0, 0, 10.0f);
    public bool isFrozen;
    [HideInInspector]
    public Vector3 speed;

    public MovingPlatform[] movingPlatforms;
    public AntiMagicBarrier[] AntiMagicBarrier;

    bool hasMovingPlatforms;
    bool hasSetSwitchActive;
    bool hasAntiMagicBarrier;

    AudioSource al;
    void Start()
    {
        al = GetComponent<AudioSource>();
        if (movingPlatforms.Length != 0)
        {
            hasMovingPlatforms = true;
        }

        if (AntiMagicBarrier.Length != 0)
        {
            hasAntiMagicBarrier = true;
        }
        speed = wheelRotation;
    }

    void Update()
    {
        if (!isFrozen)
        {
            if (hasSetSwitchActive == false)
            {
                    al.Play();
                if (hasMovingPlatforms)
                {
                    foreach (var item in movingPlatforms)
                    {
                        item.numberOfActiveSwitches++;
                        hasSetSwitchActive = true;
                    }
                    Activated(movingPlatforms);

                }

                if (hasAntiMagicBarrier)
                {
                    foreach (var item in AntiMagicBarrier)
                    {
                        item.numberofActiveSwitch++;
                        hasSetSwitchActive = true;
                    }
                }
            }

            wheel.transform.Rotate(speed * Time.deltaTime);
        }
        else
        {
            if (hasSetSwitchActive == true)
            {
                al.Stop();
                if (hasMovingPlatforms)
                {
                    foreach (var item in movingPlatforms)
                    {
                        item.numberOfActiveSwitches--;

                    }
                    Deactivated(movingPlatforms);
                }

                if (hasAntiMagicBarrier)
                {
                    foreach (var item in AntiMagicBarrier)
                    {
                        item.numberofActiveSwitch--;
                    }
                }
                hasSetSwitchActive = false;
            }
        }
    }


    public void ToggleFreeze(bool value)
    {
        isFrozen = value;
    }
}
