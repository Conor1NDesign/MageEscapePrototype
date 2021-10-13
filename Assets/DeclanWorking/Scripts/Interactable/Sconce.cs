using UnityEngine;

public class Sconce : Interactable
{
    public bool isActivated = false;
    bool hasMovingPlatforms = false;
    bool hasSetSwitchActive = false;
    public MovingPlatform[] movingPlatforms;
    public AntiMagicBarrier[] AntiMagicBarrier;
    bool hasAntiMagicBarrier;
    public GameObject particles;
    public Material NonEmmisive;
    private void OnDrawGizmos()
    {
        if (movingPlatforms.Length != 0)
        {
            foreach (var item in movingPlatforms)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, item.GetComponent<MovingPlatform>().Platform.transform.position);
            }
        }
    }

    void Start()
    {
        if (movingPlatforms.Length != 0)
        {
            hasMovingPlatforms = true;
        }
        if (AntiMagicBarrier.Length != 0)
        {
            hasAntiMagicBarrier = true;
        }
    }

    void Update()
    {
        if (isActivated)
        {
            particles.gameObject.SetActive(true);
            if (hasSetSwitchActive == false)
            {
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
        }
        else
        {
            particles.gameObject.SetActive(false);
            if (hasSetSwitchActive == true)
            {
                if (hasMovingPlatforms)
                {
                    foreach (var item in movingPlatforms)
                    {
                        item.numberOfActiveSwitches--;
                        hasSetSwitchActive = false;
                    }
                    Deactivated(movingPlatforms);

                }

                if (hasAntiMagicBarrier)
                {
                    foreach (var item in AntiMagicBarrier)
                    {
                        item.numberofActiveSwitch--;
                        hasSetSwitchActive = false;
                    }
                }
            }
        }

    }
}
