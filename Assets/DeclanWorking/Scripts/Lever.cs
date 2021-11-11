using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{

	public bool IsResetSwitch;
	public bool isActive;
	public List<MovingPlatform> movingPlatforms;
	bool isactivated;

	public GameObject inactiveMesh;
	public GameObject activeMesh;

	void Update()
	{

		if (isActive)
		{


			foreach (var item in movingPlatforms)
			{
				if (IsResetSwitch)
				{
					item.resetting = true;
				}
				else
				{
					item.numberOfActiveSwitches++;
				}

				inactiveMesh.SetActive(false);
				activeMesh.SetActive(true);
			}
		   
			Activated(movingPlatforms);
		}
		else
		{
			if (isactivated)
			{
				foreach (var item in movingPlatforms)
				{
				print("up");
					item.numberOfActiveSwitches--;
					isactivated = false;
				}
			}
		}
	}
}
