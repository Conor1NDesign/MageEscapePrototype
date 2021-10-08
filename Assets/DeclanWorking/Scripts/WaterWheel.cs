using UnityEngine;

public class WaterWheel : MonoBehaviour
{
	public GameObject wheel;
	public Vector3 wheelRotation = new Vector3(0,0,1.0f);
	public bool isFrozen;
	[HideInInspector]
	public Vector3 speed;
	
	void Start()
	{
		speed = wheelRotation;
	}

	void Update()
	{
		if (!isFrozen)
		{
			wheel.transform.Rotate(speed * Time.deltaTime);
		}
	}


	public void ToggleFreeze(bool value)
	{
		isFrozen = value;
	}
}
