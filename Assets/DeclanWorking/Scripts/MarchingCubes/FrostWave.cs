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

	RaycastHit RayHit;
	public LayerMask ignore;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Water"))
		{

			if (Physics.Linecast(transform.position, other.transform.position, out RayHit, ~ignore))
			{
				if (RayHit.collider.CompareTag("Water"))
				{
					frozenMode.MarchTheCubes(true);
					print("Freeeeze");
					return;
				}
			}

		}
		else if (other.CompareTag("Lightable"))
		{
			if (Physics.Linecast(transform.position, other.transform.position, out RayHit, ~ignore))
			{
				if (RayHit.collider.CompareTag("Lightable"))
				{
					other.gameObject.GetComponent<Sconce>().isActivated = false;
					return;
				}
			}
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

		if (other.CompareTag("Player"))
		{
			PlayerController playerController = other.GetComponent<PlayerController>();
			if (playerController)
				playerController.SetChilled(true);
		}
	}
    private void OnTriggerStay(Collider other)
    {
		Debug.DrawLine(transform.position, other.transform.position);
	}
}
