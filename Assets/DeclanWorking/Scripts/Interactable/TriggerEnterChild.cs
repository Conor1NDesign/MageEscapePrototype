using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterChild : MonoBehaviour
{
    public bool parentPlayer = true;

    public List<PlayerController> cc;
    public List<GameObject> Children;
    // Start is called before the first frame update
    public Vector3 linearVel;

    private Vector3 previousPosition = Vector3.zero;
    void Start()
    {
        cc = new List<PlayerController>();
        Children = new List<GameObject>();
    }


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
            //Debug.Log(linearVel);
            item.Move((linearVel + item.moveDirection));
            // print(linearVel + item.moveDirection);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (!other.CompareTag("Spellbook"))
            {
                if (other.tag == "Player" && parentPlayer)
                {
                    other.gameObject.transform.parent = gameObject.transform;
                    cc.Add(other.gameObject.GetComponent<PlayerController>());
                    if (!Children.Contains(other.gameObject))
                    {
                        Children.Add(other.gameObject);
                    }

                }

                if (other.tag == "Heavy Object" && !parentPlayer)
                {
                    print("parent");
                    other.gameObject.transform.parent = gameObject.transform;
                    if (!Children.Contains(other.gameObject))
                    {
                        Children.Add(other.gameObject);
                    }
                }
            }
        }
        catch
        {
            print("q");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        try
        {

            if (!other.CompareTag("Spellbook") && !other.isTrigger)
            {
                if (other.tag == "Player")
                {
                    other.gameObject.transform.parent = null;
                    cc.Remove(other.gameObject.GetComponent<PlayerController>());
                    Children.Remove(other.gameObject);

                }
                if (other.tag == "Heavy Object" && !parentPlayer)
                {
                    Children.Remove(other.gameObject);

                }
            }


        }
        catch
        {
            print("qq");
        }
    }


    private void OnDestroy()
    {
        try
        {
            print("DESTROY");
            foreach (var item in Children)
            {
                if (item.tag == "Heavy Object" || item.tag == "Heavy Object")
                {
                    print(item.name);
                    item.gameObject.transform.parent = null;
                }
            }
        }
        catch
        {
            print("qqq");
        }
    }
    private void OnDisable()
    {
        cc.Clear();
        enabled = true;
    }
}
