using UnityEngine;

public class BoulderIceCollision : MonoBehaviour
{
	FrozonMode frozenMode;

	void Awake()
	{
		frozenMode = GetComponent<FrozonMode>();
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ice"))
			frozenMode.MarchTheCubes(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Water"))
			frozenMode.MarchTheCubes(false);
	}
}
