using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterChild : MonoBehaviour
{
    public bool parentPlayer = true;
    
    public List<PlayerController> cc;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }
    public Vector3 linearVel;
    Vector3 prevPos;
    float prevRealTime;
    private Vector3 previousPosition = Vector3.zero;
    private Quaternion previousRotation = Quaternion.identity;
    bool moving;
    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        linearVel = (transform.position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = transform.position;


        foreach (var item in cc)
        {
            Debug.Log(linearVel);
            item.Move((linearVel + item.moveDirection));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && parentPlayer)
        {
            other.gameObject.transform.parent = gameObject.transform;
          //  cc.Add(other.gameObject.GetComponent<PlayerController>());

        }

        if (other.tag == "Heavy Object" && !parentPlayer)
        {
            print("parent");
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.parent = null;
            cc.Remove(other.gameObject.GetComponent<PlayerController>());
          
        }
        if (other.tag == "Heavy Object" && !parentPlayer)
        {
            print("no parent");
            other.gameObject.transform.parent = null;
        }
    }


}
