using UnityEngine;

public class AntiMagicBarrier : MonoBehaviour
{

    PlayerController[] casters;
    public int numberOfRequiredSwitches;
    public int numberofActiveSwitch;

    public GameObject Barrier;
    public BoxCollider[] BarrierCollider;

    [Header("If there is more than one Barrier only check this on one")]
    public bool DoesItNeedSound = false;
    AudioSource al;


    void Awake()
    {
        al = GetComponent<AudioSource>();

    }

    void Start()
    {
        casters = FindObjectsOfType<PlayerController>();
        if (DoesItNeedSound)
        {
            al.Play();
        }
    }

    private void Update()
    {
        if (numberofActiveSwitch == numberOfRequiredSwitches)
        {
            if (Barrier.activeSelf == false)
            {
                if (DoesItNeedSound)
                {
                    al.Play();
                }
            }
            Activate();


        }
        else
        {

            if (Barrier.activeSelf == true)
            {
                if (DoesItNeedSound)
                {
                    al.Stop();
                }
            }
            Deactivate();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spellbook"))
        {
            SpellbookController spellbook = other.GetComponent<SpellbookController>();
            if (spellbook)
                spellbook.Respawn();
        }

        if (other.gameObject.layer == 8)
        {
            PlayerController caster = other.GetComponent<SpellCharacterController>().playerCasting;
            caster.tornadoActive = false;
            caster.tornado = null;
            Destroy(other.gameObject);
        }
    }

    public void Activate()
    {
        Barrier.SetActive(true);
        foreach (var item in BarrierCollider)
        {
            item.enabled = true;
        }

    }
    public void Deactivate()
    {
        Barrier.SetActive(false);
        foreach (var item in BarrierCollider)
        {
            item.enabled = false;
        }
    }
}
