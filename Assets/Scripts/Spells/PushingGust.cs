using System.Collections.Generic;
using UnityEngine;

public class PushingGust : MonoBehaviour
{

	public float gustSpeedModifier = 1;
	[HideInInspector]
	public List<GameObject> inBeam;

	private void Start()
	{
		inBeam = new List<GameObject>();
	}

	RaycastHit RayHit;


		

    private void OnTriggerEnter(Collider other)
	{
			
		if (other.CompareTag("Lightable"))
		{

			if (Physics.Linecast(other.transform.position + new Vector3(0,1,0), transform.parent.position, out RayHit) && RayHit.collider.gameObject.CompareTag("Player"))
			{

				print("sight");
				other.gameObject.GetComponent<Sconce>().isActivated = false;
			}
			else
			{
				print(RayHit.collider.name);
				print("nosight");
			}
		}

		if (other.CompareTag("Heavy Object"))
		{

		}

		if (other.CompareTag("Player"))
		{
			inBeam.Add(other.gameObject);
		}

	}
	private void OnTriggerStay(Collider other)
	{
		Debug.DrawLine(other.transform.position + new Vector3(0, 1, 0), transform.parent.position);
		if (other.CompareTag("Player"))
		{
			// other.gameObject.transform.parent = gameObject.transform;
			other.GetComponent<PlayerController>().useGravity = false;
			other.GetComponent<PlayerController>().Move((transform.forward * gustSpeedModifier) + other.GetComponent<PlayerController>().moveDirection);
		}
		if (other.CompareTag("Meltable"))
		{
			WaterWheel WW = other.GetComponent<WaterWheel>();
			if (WW != null)
			{
				WW.speed = new Vector3(WW.wheelRotation.x, WW.wheelRotation.y, WW.wheelRotation.z * 5);
				print("WEEEEEEEEEEEEEE");
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		foreach (var item in inBeam)
		{
			if (item.name == "Player 1" || item.name == "Player 2")
			{
				item.GetComponent<PlayerController>().useGravity = true;
			}
		}
		if (other.CompareTag("Meltable"))
		{
			WaterWheel WW = other.GetComponent<WaterWheel>();
			if (WW != null)
			{
				WW.speed = WW.wheelRotation;
			}
		}

	}
	private void OnDrawGizmos()
	{

	}
}

