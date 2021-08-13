using UnityEngine;

public class SpellFunctions : MonoBehaviour
{
    delegate void SpellFunction(PlayerController caster);
    static SpellFunction[] quickCastSpells = { Flamethrower, QuickFrost, QuickEarth, PushingGust };
    static SpellFunction[] hardCastSpells = { Fireball, HardFrost, HardEarth, TornadoGust };
    static SpellFunction[] quickCastEnd = { FlamethrowerEnd, QuickFrostEnd, QuickEarthEnd, PushingGustEnd };
    static SpellFunction[] hardCastEnd = { FireballEnd, HardFrostEnd, HardEarthEnd, TornadoGustEnd };

    public static void StartQuickCast(PlayerController caster)
    {
        quickCastSpells[(int)caster.playerElement - 1](caster);
    }

    public static void StartHardCast(PlayerController caster)
    {
        hardCastSpells[(int)caster.playerElement - 1](caster);
    }
    public static void EndQuickCast(PlayerController caster)
    {
        quickCastEnd[(int)caster.playerElement - 1](caster);
    }

    public static void EndHardCast(PlayerController caster)
    {
        hardCastEnd[(int)caster.playerElement - 1](caster);
    }

    // -----------------
    // Quick Cast Spells
    // -----------------

    static void Flamethrower(PlayerController caster)
    {
        Debug.Log("Flamethrower");
        caster.AttachSpell(Instantiate(caster.flamethrowerPrefab));
    }

    static void QuickFrost(PlayerController caster)
    {
        Debug.Log("QuickFrost");
    }

    static void QuickEarth(PlayerController caster)
    {
        Debug.Log("QuickEarth");
    }

    static void PushingGust(PlayerController caster)
    {
        Debug.Log("Pushing Gust");
        caster.AttachSpell(Instantiate(caster.gustPrefab));
        caster.rotationLockedBySpell = true;
    }

    // ----------------
    // Hard Cast Spells
    // ----------------

    static void Fireball(PlayerController caster)
    {
        Debug.Log("Fireball Aim");
        caster.AttachSpell(Instantiate(caster.fireballPrefab));
    }

    static void HardFrost(PlayerController caster)
    {
        Debug.Log("HardFrost");
    }

    static void HardEarth(PlayerController caster)
    {
        Debug.Log("HardEarth");
    }

    static void TornadoGust(PlayerController caster)
    {
        Debug.Log("Tornado Gust");

        caster.tornado = Instantiate(caster.tornadoLiftPrefab, caster.spellAttachPoint.position, Quaternion.identity);

        caster.tornado.transform.position = caster.transform.position;
        
        caster.tornado.GetComponent<SpellCharacterController>().PlayerCon = caster;
        caster.tornadoActive = true;
    }

    // -----------------
    // Spell Endings
    // -----------------

    static void FlamethrowerEnd(PlayerController caster)
    {
        Debug.Log("Flamethrower End");
        Destroy(caster.ClearSpell());
    }

    static void QuickFrostEnd(PlayerController caster)
    {
        Debug.Log("QuickFrostEnd");
    }

    static void QuickEarthEnd(PlayerController caster)
    {
        Debug.Log("QuickEarthEnd");
    }

    static void PushingGustEnd(PlayerController caster)
    {
        Debug.Log("Pushing Gust End");
        caster.rotationLockedBySpell = false;
        if (caster.playerIndex == 0)
        {
            GameObject.Find("Player 2").GetComponent<PlayerController>().useGravity = true;
        }
        else
        if (caster.playerIndex == 1)
        {
            GameObject.Find("Player 1").GetComponent<PlayerController>().useGravity = true;
        }

        Destroy(caster.ClearSpell());
    }

    static void FireballEnd(PlayerController caster)
    {
        Debug.Log("Fireball Shoot");
        GameObject fireball = caster.ClearSpell();
        if (fireball)
        {
            fireball.GetComponent<Rigidbody>().AddForce(caster.transform.forward * caster.fireballForce, ForceMode.Impulse);
            Destroy(fireball, caster.fireballTime);
        }
    }

    static void HardFrostEnd(PlayerController caster)
    {
        Debug.Log("HardFrostEnd");
    }

    static void HardEarthEnd(PlayerController caster)
    {
        Debug.Log("HardEarthEnd");
    }

    static void TornadoGustEnd(PlayerController caster)
    {
        Destroy(caster.tornado);
        caster.tornadoActive = false;
        
    }
}
