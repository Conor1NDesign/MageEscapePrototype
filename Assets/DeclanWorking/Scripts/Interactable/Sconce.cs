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

    public AudioClip light;
    public AudioClip putOut;
    AudioSource al;

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

        al = GetComponent<AudioSource>();
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
            if (particles.gameObject.activeSelf == false)
            {
                al.clip = light;
                al.Play();
            }


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

            if (particles.gameObject.activeSelf == true)
            {
                al.clip = putOut;
                al.Play();
            }

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
