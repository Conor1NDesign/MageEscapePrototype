using UnityEngine;

public class Sconce : Interactable
{
	public bool isActivated = false;
	bool hasMovingPlatforms = false;
	bool hasSetSwitchActive = false;
	public MovingPlatform[] movingPlatforms;
	public GameObject particles;
	public Material NonEmmisive;
	private void OnDrawGizmos()
	{
		if (movingPlatforms.Length != 0)
		{
			foreach (var item in movingPlatforms)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(transform.position, item.GetComponent<MovingPlatform>().Platform.transform.position);
			}
		}
	}
	
	void Start()
	{
		if (movingPlatforms.Length != 0)
		{
			hasMovingPlatforms = true;
		}
	}
	
	void Update()
	{
		if (isActivated)
		{
			particles.gameObject.SetActive(true);
			if (hasMovingPlatforms)
			{
				if (hasSetSwitchActive == false)
				{
					foreach (var item in movingPlatforms)
					{
						item.numberOfActiveSwitches++;
						hasSetSwitchActive = true;
					}
					Activated(movingPlatforms);
				}
			}
		}
		else
		{
			particles.gameObject.SetActive(false);
			if (hasMovingPlatforms)
			{
				if (hasSetSwitchActive == true)
				{
					foreach (var item in movingPlatforms)
					{
						item.numberOfActiveSwitches--;
						hasSetSwitchActive = false;
					}
					Deactivated(movingPlatforms);
				}
			}
		}

	}
}
