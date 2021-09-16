using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Interactable : MonoBehaviour
{

    
    public void Activated(MovingPlatform[] objects)
    {
        
        foreach (var item in objects)
        {
            item.Actived();
        }
    }
    public void Activated(List<MovingPlatform> objects)
    {

        foreach (var item in objects)
        {
            if (item.numberOfActiveSwitches == item.numberOfSwitches)
            { 

            item.Actived();
            }
        }
    }


    public void Activated(Scone[] objects)
    {


    }


    public void Deactivated(MovingPlatform[] objects)
    {

        foreach (var item in objects)
        {
            item.Deactived();
        }
    }
    public void Deactivated()
    {

    }

    


}
