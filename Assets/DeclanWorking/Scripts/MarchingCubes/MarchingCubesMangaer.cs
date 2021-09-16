using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubesMangaer : MonoBehaviour
{

    public float yOffsetOfMesh = 0.5f;
    //[HideInInspector]
    public WaterFreeze[] WaterTiles;
   // [HideInInspector]
    public BoxCollider[] WaterTilesColliders;
    //[HideInInspector]
    public GameObject IceMeshes;
    void Start()
    {
        WaterTiles = FindObjectsOfType<WaterFreeze>();
        WaterTilesColliders = new BoxCollider[WaterTiles.Length];
        IceMeshes = new GameObject("Ice Mesh");

        for (int i = 0; i < WaterTiles.Length; i++)
        {
            WaterTilesColliders[i] = WaterTiles[i].transform.parent.GetComponent<BoxCollider>();
            WaterTiles[i].mesh = new Mesh();
            WaterTiles[i].GroundMesh = new GameObject("Mesh ", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
            WaterTiles[i].GroundMesh.transform.parent = IceMeshes.transform;
            WaterTiles[i].GroundMesh.transform.position = new Vector3(WaterTiles[i].GroundMesh.transform.position.x, yOffsetOfMesh, WaterTiles[i].GroundMesh.transform.position.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
