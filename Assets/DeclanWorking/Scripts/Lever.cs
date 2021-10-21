using System.Collections.Generic;

public class Lever : Interactable
{

	public bool IsResetSwitch;
	public bool isActive;
	public List<MovingPlatform> movingPlatforms;
	bool isactivated;
	
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
