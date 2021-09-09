using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlade : MonoBehaviour
{

    public float normalSpeed = 200;
    public float slowedSpeed = 50;
    public float slowEffectDuration = 5;
    public bool isSlowed;
    [HideInInspector]
    public float counter;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isSlowed)
        {
            speed = normalSpeed;
        }
        else
        { 
            speed = slowedSpeed;
            counter += Time.deltaTime;
            if (counter > slowEffectDuration)
            {
                isSlowed = false;
            }
        }
        transform.Rotate(new Vector3(0, 1 * speed * Time.deltaTime, 0), Space.Self);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSlowed)
        {
            PlayerController controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.isDead = true;
            }
        }
        if (other.CompareTag("Spellbook") && !isSlowed)
        {
            SpellbookController controller = other.GetComponent<SpellbookController>();
            print("spellbook");
            if (controller)
            {
            print("spellbook1");
                controller.Respawn();
            }
        }
    }
}
