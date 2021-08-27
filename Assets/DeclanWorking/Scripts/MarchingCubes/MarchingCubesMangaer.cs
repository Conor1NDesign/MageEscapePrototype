using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubesMangaer : MonoBehaviour
{
    //[HideInInspector]
    public WaterFreeze[] WaterTiles;
   // [HideInInspector]
    public BoxCollider[] WaterTilesColliders;
    [HideInInspector]
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
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
