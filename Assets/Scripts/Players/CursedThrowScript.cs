using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedThrowScript : MonoBehaviour
{
    public Animator cursed;
    public bool inputEnded = false;

    public PlayerController thePlayer;

    public void PauseTheThrow()
    {
        Debug.Log("Hey the throw input is currently: "+inputEnded);
        if (!inputEnded)
            cursed.speed = 0;
        else
        {
            cursed.speed = 1;
            inputEnded = false;
        }

        if (thePlayer.spellbook == null)
            cursed.speed = 1;
    }

    public void ThrowBook()
    {
        thePlayer.InteractWithSpellbook(true);
    }

    public void Interaction()
    {
        thePlayer.InteractionEnds();
    }    
}
