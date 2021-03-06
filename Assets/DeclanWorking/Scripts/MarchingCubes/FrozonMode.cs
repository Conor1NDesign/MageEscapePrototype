using UnityEngine;

public class FrozonMode : MonoBehaviour
{
	private BoxCollider[] Cone;
	private BoxCollider Incapsulating;

	bool dirty;


	//public GameObject[] WaterTiles;
	private BoxCollider[] WaterTilesColliders;
	//MeshCollider[] WaterTilesNeeded;
	int[] WaterTilesNeeded;

	// public LineRenderer lineRenderer;

	private MarchingCubesMangaer marchingCubeManager;
	private ColliderTracker colliderTracker;
	
	void Awake()
	{
		//colliderTracker = FindObjectOfType<ColliderTracker>();
		colliderTracker = gameObject.GetComponentInChildren<ColliderTracker>();
		Incapsulating = colliderTracker.Incapsulating;
		Cone = colliderTracker.BoxedCone;
		marchingCubeManager = FindObjectOfType<MarchingCubesMangaer>();
		WaterTilesNeeded = new int[marchingCubeManager.WaterTiles.Length];
	}

	public void MarchTheCubes(bool freezing)
	{
		int count = -1;

		if (marchingCubeManager != null)
		{
			foreach (var item in marchingCubeManager.WaterTilesColliders)
			{
				count++;
				if (Incapsulating.bounds.Intersects(item.bounds))
				{
					WaterTilesNeeded[count] = count;
				}
			}
		}

		dirty = false;
		int q = 0;

		foreach (var items in WaterTilesNeeded)
		{
			for (int y = 0; y < 1; y++)
			{
				for (int z = 0; z < marchingCubeManager.WaterTiles[items].GetGridSize(); z++)
				{
					for (int x = 0; x < marchingCubeManager.WaterTiles[items].GetGridSize(); x++)
					{
						if (Incapsulating.bounds.Contains(marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].pos) && !marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].frozen && freezing)
						{
							foreach (BoxCollider item in Cone)
							{
								if (item.bounds.Contains(marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].pos))
								{
									marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].frozen = true;
									dirty = true;
								}
							}
						}
						else if (Incapsulating.bounds.Contains(marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].pos) && marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].frozen == true && !freezing)
						{
							foreach (BoxCollider item in Cone)
							{
								if (item.bounds.Contains(marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].pos))
								{
									print("Defrosting");
									marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].frozen = false;
									dirty = true;
								}
							}
						}
					}
				}
				
				if (dirty)
				{
					marchingCubeManager.WaterTiles[items].MarchingCubes();

					marchingCubeManager.WaterTiles[items].mesh.vertices = marchingCubeManager.WaterTiles[items].verts.ToArray();
					marchingCubeManager.WaterTiles[items].mesh.triangles = marchingCubeManager.WaterTiles[items].tri.ToArray();

					marchingCubeManager.WaterTiles[items].GroundMesh.GetComponent<MeshRenderer>().material = marchingCubeManager.WaterTiles[items].SurfaceMat;
					marchingCubeManager.WaterTiles[items].GroundMesh.GetComponent<MeshRenderer>().receiveShadows = false;
					marchingCubeManager.WaterTiles[items].GroundMesh.GetComponent<MeshCollider>().sharedMesh = marchingCubeManager.WaterTiles[items].mesh;
					marchingCubeManager.WaterTiles[items].mesh.RecalculateNormals();
					marchingCubeManager.WaterTiles[items].GroundMesh.GetComponent<MeshFilter>().mesh = marchingCubeManager.WaterTiles[items].mesh;
				}
				q++;
			}
			WaterTilesNeeded = new int[marchingCubeManager.WaterTiles.Length];
		}
	}
}







