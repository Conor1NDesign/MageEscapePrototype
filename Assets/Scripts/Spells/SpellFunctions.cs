using UnityEngine;

public class SpellFunctions : MonoBehaviour
{
    delegate void SpellFunction(PlayerController caster);
    static SpellFunction[] quickCastSpells = { Flamethrower, FrostWave, EarthPlatform, PushingGust };
    static SpellFunction[] hardCastSpells = { Fireball, IceBeam, SummonBoulder, TornadoGust };
    static SpellFunction[] quickCastEnd = { FlamethrowerEnd, FrostWaveEnd, EarthPlatformEnd, PushingGustEnd };
    static SpellFunction[] hardCastEnd = { FireballEnd, IceBeamEnd, SummonBoulderEnd, TornadoGustEnd };

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

    static void FrostWave(PlayerController caster)
    {
        caster.AttachSpell(Instantiate(caster.frostWavePrefab));
        caster.attachedSpell.transform.GetChild(0).Rotate(0, 0, -90);
        caster.attachedSpell.transform.GetChild(0).Translate(0, 2, -1.8f);
        Debug.Log("FrostWave");
    }

    public static void EarthPlatform(PlayerController caster)
    {
        Debug.Log("Earth Platform");
		if (caster.earthPlatform)
			Destroy(caster.earthPlatform);
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

    static void IceBeam(PlayerController caster)
    {
        Debug.Log("IceBeam");
    }

    static void SummonBoulder(PlayerController caster)
    {
        Debug.Log("Boulder Target");
		GameObject boulderTarget = caster.boulderTargetPrefab;
		caster.AttachSpell(Instantiate(boulderTarget));
		boulderTarget.transform.localPosition = -caster.spellAttachPoint.transform.localPosition;
        boulderTarget.GetComponent<SpellCharacterController>().playerCon = caster;
        caster.tornadoActive = true;
    }

    static void TornadoGust(PlayerController caster)
    {
        Debug.Log("Tornado Gust");

        caster.tornado = Instantiate(caster.tornadoLiftPrefab, caster.spellAttachPoint.position, Quaternion.identity);

        caster.tornado.transform.position = caster.transform.position;
        
        caster.tornado.GetComponent<SpellCharacterController>().playerCon = caster;
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

    static void FrostWaveEnd(PlayerController caster)
    {
        Debug.Log("FrostWaveEnd");
        Destroy(caster.ClearSpell());
    }

    static void EarthPlatformEnd(PlayerController caster)
    {
        Debug.Log("Earth Platform Place");
		caster.earthPlatform = Instantiate(caster.earthPlatformPrefab);
		caster.earthPlatform.transform.position = caster.transform.position + caster.transform.forward - new Vector3(0f, 0.2f, 0.0f);
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
			fireball.GetComponent<Fireball>().aging = true;
        }
    }

    static void IceBeamEnd(PlayerController caster)
    {
        Debug.Log("IceBeamEnd");
    }

    static void SummonBoulderEnd(PlayerController caster)
    {
        Debug.Log("Summon Boulder");
		GameObject boulder = Instantiate(caster.boulderPrefab);
		GameObject boulderTarget = caster.ClearSpell();
		if (!boulderTarget)
			return;
		
		boulder.transform.position = boulderTarget.transform.position + new Vector3(0.0f, 3.0f, 0.0f);
		Destroy(boulderTarget);
    }

    static void TornadoGustEnd(PlayerController caster)
    {
        Destroy(caster.tornado);
        caster.tornadoActive = false;
        
    }
}
