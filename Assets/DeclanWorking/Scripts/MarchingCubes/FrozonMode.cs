using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using UnityEngine.SceneManagement;
using TMPro;

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
    // Start is called before the first frame update
    void Start()
    {
        colliderTracker = FindObjectOfType<ColliderTracker>();
        Incapsulating = colliderTracker.Incapsulating;
        Cone = colliderTracker.BoxedCone;
        marchingCubeManager = FindObjectOfType<MarchingCubesMangaer>();
        WaterTilesNeeded = new int[marchingCubeManager.WaterTiles.Length];
    }





    // Update is called once per frame
    public void MarchTheCubes()
    {

        int count = -1;
        
        foreach (var item in marchingCubeManager.WaterTilesColliders)
        {
            count++;
            if (Incapsulating.bounds.Intersects(item.bounds))
            {
                WaterTilesNeeded[count] = count;
                
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
                        if (Incapsulating.bounds.Contains(marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].pos) && !marchingCubeManager.WaterTiles[items].gridPoints[x, y, z].frozen)
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







