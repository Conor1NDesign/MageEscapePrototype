using UnityEngine;

public class FrostWave : MonoBehaviour
{
	ColliderTracker colliderTracker;
	public FrozonMode frozenMode;
	
	void Start()
	{
		//frozenMode = FindObjectOfType<FrozonMode>();
		colliderTracker = FindObjectOfType<ColliderTracker>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Water"))
		{
			frozenMode.MarchTheCubes(true);
			print("Freeeeze");
			return;
		}
		else if (other.CompareTag("Lightable"))
		{
			other.GetComponent<Sconce>().isActivated = false;
			return;
		}
		else if (other.CompareTag("Meltable"))
		{
			other.GetComponent<WaterWheel>().isFrozen = true;
		}
		
		SpinningBlade sb = other.GetComponent<SpinningBlade>();
		if (sb!= null)
		{
			sb.isSlowed = true;
			sb.counter = 0.0f;
		}
	}
}
