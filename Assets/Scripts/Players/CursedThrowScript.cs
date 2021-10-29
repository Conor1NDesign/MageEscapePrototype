using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedThrowScript : MonoBehaviour
{
    public Animator cursed;

    public PlayerController thePlayer;

    public void PauseTheThrow()
    {
        cursed.speed = 0;

        if (thePlayer.spellbook == null)
            cursed.speed = 1;
    }

    public void ThrowBook()
    {
        thePlayer.InteractWithSpellbook(true);
    }
}
