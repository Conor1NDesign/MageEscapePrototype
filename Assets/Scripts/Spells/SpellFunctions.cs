using UnityEngine;

public class SpellFunctions : MonoBehaviour
{
    delegate void SpellFunction(PlayerController caster);
    static SpellFunction[] quickCastSpells = { Flamethrower, QuickFrost, QuickEarth, QuickWind };
    static SpellFunction[] hardCastSpells = { Fireball, HardFrost, HardEarth, HardWind };

    public static void QuickCast(PlayerController caster)
    {
        quickCastSpells[(int)caster.playerElement - 1](caster);
    }

    public static void HardCast(PlayerController caster)
    {
        hardCastSpells[(int)caster.playerElement - 1](caster);
    }

    // -----------------
    // Quick Cast Spells
    // -----------------

    static void Flamethrower(PlayerController caster)
    {
        Debug.Log("Flamethrower");
    }

    static void QuickFrost(PlayerController caster)
    {
        Debug.Log("QuickFrost");
    }

    static void QuickEarth(PlayerController caster)
    {
        Debug.Log("QuickEarth");
    }

    static void QuickWind(PlayerController caster)
    {
        Debug.Log("QuickWind");
    }

    // ----------------
    // Hard Cast Spells
    // ----------------

    static void Fireball(PlayerController caster)
    {
        Debug.Log("Fireball");
    }

    static void HardFrost(PlayerController caster)
    {
        Debug.Log("HardFrost");
    }

    static void HardEarth(PlayerController caster)
    {
        Debug.Log("HardEarth");
    }

    static void HardWind(PlayerController caster)
    {
        Debug.Log("HardWind");
    }
}
