using UnityEngine;

public class SpellFunctions : MonoBehaviour
{
	delegate void SpellFunction(PlayerController caster);
	static SpellFunction[] quickCastSpells = { Flamethrower, FrostWave, EarthPlatform, PushingGust };
	static SpellFunction[] hardCastSpells = { Fireball, IceBeam, SummonBoulder, TornadoGust };
	static SpellFunction[] quickCastEnd = { FlamethrowerEnd, FrostWaveEnd, EarthPlatformEnd, PushingGustEnd };
	static SpellFunction[] hardCastEnd = { FireballEnd, IceBeamEnd, SummonBoulderEnd, TornadoGustEnd };


    #region START CAST
    public static void StartQuickCast(PlayerController caster)
	{
		if (caster.currentCooldown < 0.0f ||
			caster.playerElement == PlayerController.PlayerCurrentElement.Earth)
		{
			caster.currentCooldown = caster.quickCastCooldown;
			quickCastSpells[(int)caster.playerElement - 1](caster);
			caster.isHardCasting = false;
		}
	}

	public static void StartHardCast(PlayerController caster)
	{
		if (caster.currentCooldown < 0.0f)
		{
			caster.currentCooldown = caster.hardCastCooldown;
			hardCastSpells[(int)caster.playerElement - 1](caster);
			caster.isHardCasting = true;
		}
	}
	public static void EndQuickCast(PlayerController caster)
	{
		quickCastEnd[(int)caster.playerElement - 1](caster);
	}

	public static void EndHardCast(PlayerController caster)
	{
		hardCastEnd[(int)caster.playerElement - 1](caster);
	}
	#endregion

	#region QUICK CAST
	// -----------------
	// Quick Cast Spells
	// -----------------

	static void Flamethrower(PlayerController caster)
	{
		Debug.Log("Flamethrower");

		
		GameObject flamethrower = Instantiate(caster.flamethrowerPrefab);
		caster.AttachSpell(flamethrower);
		flamethrower.GetComponent<Flamethrower>().playerCasting = caster;
		caster.attachedSpell.GetComponent<AudioSource>().clip = caster.AudioManager.flameThrowerLoop;
		caster.attachedSpell.GetComponent<AudioSource>().volume = 0.13f;
		caster.attachedSpell.GetComponent<AudioSource>().Play();
	}

	static void FrostWave(PlayerController caster)
	{
		caster.AttachSpell(Instantiate(caster.frostWavePrefab));
		Debug.Log("FrostWave");
	}

	public static void EarthPlatform(PlayerController caster)
	{
		Debug.Log("Earth Platform");
		if (caster.earthPlatform)
		{
			Destroy(caster.earthPlatform);
			caster.earthPlatform = null;
		}
	}

	static void PushingGust(PlayerController caster)
	{

		caster.AttachSpell(Instantiate(caster.gustPrefab));
		caster.rotationLockedBySpell = true;
	}

	#endregion

	#region HARD CAST

	// ----------------
	// Hard Cast Spells
	// ----------------

	static void Fireball(PlayerController caster)
	{
		
		caster.AttachSpell(Instantiate(caster.fireballPrefab));
		caster.attachedSpell.GetComponent<AudioSource>().clip = caster.AudioManager.fireBallLoop;
		caster.attachedSpell.GetComponent<AudioSource>().Play();
	}

	static void IceBeam(PlayerController caster)
	{
		caster.AttachSpell(Instantiate(caster.frostBeamPrefab));
		Debug.Log("IceBeam");
	}

	static void SummonBoulder(PlayerController caster)
	{
		Debug.Log("Boulder Target");
		GameObject boulderTarget = caster.boulderTargetPrefab;
		caster.tornado = Instantiate(boulderTarget, caster.spellAttachPoint.position, Quaternion.identity);
		boulderTarget.GetComponent<SpellCharacterController>().playerCasting = caster;
		boulderTarget.GetComponent<CharacterController>().detectCollisions = false;
		caster.tornadoActive = true;
		
		if (caster.boulder)
		{
			Destroy(caster.boulder);
			caster.boulder = null;
		}
	}

	static void TornadoGust(PlayerController caster)
	{

		if (caster.tornadoActive == true)
		{
			caster.tornadoActive = false;
		}
		else
		{ 
			GameObject tornadoTarget = caster.tornadoTargetPrefab;
			caster.tornado = Instantiate(tornadoTarget, caster.spellAttachPoint.position, Quaternion.identity);
			tornadoTarget.GetComponent<SpellCharacterController>().playerCasting = caster;
			caster.tornadoActive = true;
		}
	}

	#endregion

	#region END CAST


	// -----------------
	// Spell Endings
	// -----------------

	static void FlamethrowerEnd(PlayerController caster)
	{
		Debug.Log("Flamethrower End");
		GameObject flamethrower = caster.ClearSpell();
		Flamethrower flamethrowerScript = null;
		if (flamethrower)
			flamethrowerScript = flamethrower.GetComponent<Flamethrower>();
		if (flamethrowerScript && flamethrowerScript.iceWall)
			flamethrowerScript.iceWall.melting = false;

		flamethrower.GetComponent<AudioSource>().Stop();
		Destroy(flamethrower);
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
		caster.earthPlatform.transform.position = caster.transform.position + caster.transform.forward * caster.earthPlatformForwardness - new Vector3(0f, 0.1f, 0.0f);
		caster.earthPlatform.transform.rotation = caster.transform.rotation;
		caster.earthPlatform.GetComponent<EarthPlatform>().playerCasting = caster;
	}

	static void PushingGustEnd(PlayerController caster)
	{

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
			fireball.GetComponent<AudioSource>().Stop();
			fireball.GetComponent<AudioSource>().clip = caster.AudioManager.fireBall;
			fireball.GetComponent<AudioSource>().Play();
		}
	}

	static void IceBeamEnd(PlayerController caster)
	{
		Destroy(caster.ClearSpell());
		Debug.Log("IceBeamEnd");
	}

	static void SummonBoulderEnd(PlayerController caster)
	{
		Debug.Log("Summon Boulder");
		GameObject boulderTarget = caster.tornado;
		caster.tornado = null;
		if (!boulderTarget)
			return;

		GameObject boulder = Instantiate(caster.boulderPrefab);
		boulder.transform.position = boulderTarget.transform.position + new Vector3(0.0f, 3.0f, 0.0f);
		Destroy(boulderTarget);
		caster.tornadoActive = false;
		caster.boulder = boulder;
		boulder.GetComponent<Boulder>().playerCasting = caster;
	}

	static void TornadoGustEnd(PlayerController caster)
	{
		if (caster.tornadoActive)
		{
			GameObject tornado = Instantiate(caster.tornadoLiftPrefab, caster.tornado.transform.position, Quaternion.identity);
			GameObject tornadoTarget = caster.tornado;
			caster.tornado = null;
			if (!tornadoTarget)
				return;

			tornadoTarget.transform.position = tornadoTarget.transform.position + new Vector3(0.0f, 3.0f, 0.0f);
			Destroy(tornadoTarget);
			caster.tornado = tornado;
			caster.tornado.GetComponent<SpellCharacterController>().playerCasting = caster;
			caster.tornado.GetComponent<TornadoGust>().caster = caster;
			caster.playerState = PlayerController.PlayerStates.Casting;
			caster.currentCooldown = 0.0f;
		}
		else
		{
			Destroy(caster.tornado);
			caster.tornado = null;
			caster.playerState = PlayerController.PlayerStates.Idle;
		}

	} 
	#endregion
}
