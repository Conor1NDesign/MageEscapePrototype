using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterChild : MonoBehaviour
{
    [HideInInspector]
    public bool parentPlayer = true;
    [HideInInspector]
    public List<PlayerController> cc;
    //[HideInInspector]
    public List<GameObject> Children;
    [HideInInspector]
    public Vector3 linearVel;
    bool hasChild = false;
    BoxCollider bc;

    private Vector3 previousPosition = Vector3.zero;
    void Start()
    {
        cc = new List<PlayerController>();
        Children = new List<GameObject>();
        bc = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        //Calculates the velocity of the parent object
        linearVel = (transform.position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = transform.position;

        if (Children.Count == 0)
        {
            bc.enabled = true;
        }
        else
        { 
            bc.enabled = false;
        }

        //Add the velocity to the players move direction
        foreach (var item in cc)
        {
            item.Move((linearVel + item.moveDirection));
        }
    }

    /// <summary>
    /// When a Player or Heavy Object enters the trigger
    /// Get the player controller
    /// Set the player and Heavy object as children of
    /// the objects depending if you allow the player to become a child
    /// </summary>
    /// <param name="other"></param>
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

                if ((other.tag == "Heavy Object" || other.tag == "MM") && !parentPlayer && !hasChild)
                {

                    if (other.CompareTag("MM") && other.name != "MirrorCollider")
                    {
                        other.gameObject.transform.parent = gameObject.transform;
                        hasChild = true;
                    }
                    else
                    {
                        hasChild = true;
                        other.gameObject.transform.parent = gameObject.transform;
                    }
                    if (!Children.Contains(other.gameObject))
                    {
                        if (other.name != "MirrorCollider")
                        {


                            Children.Add(other.gameObject);
                        }
                    }
                }
            }
        }
        catch
        {
            print("q");
        }
    }

    /// <summary>
    /// If an object leaves the trigger remove it from all the list 
    /// </summary>
    /// <param name="other"></param>
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
                if ((other.tag == "Heavy Object" || other.tag == "MM") && !parentPlayer)
                {

                    if (other.tag == "MM")
                    {
                        hasChild = false;
                        Children.Remove(other.gameObject.transform.parent.gameObject);
                    }
                    else
                    {
                        hasChild = false;
                        Children.Remove(other.gameObject);

                    }
                }
            }
        }
        catch
        {
            print("qq");
        }
    }

    /// <summary>
    /// On Destroy  unpartent all the added children objects
    /// </summary>
    private void OnDestroy()
    {
        try
        {

            foreach (var item in Children)
            {
                item.gameObject.transform.parent = null;
            }
        }
        catch
        {
            print("ERROR");
        }
    }

    private void OnDisable()
    {
        cc.Clear();
        enabled = true;
    }
}
