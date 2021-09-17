using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHeavyObject : MonoBehaviour
{
    public float respawnTime = 2;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    public void Respawn()
    {
        StartCoroutine(RespawnBlock());
    }

    public IEnumerator RespawnBlock()
    {
        
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        transform.position = startPos;
        yield return new WaitForSeconds(respawnTime);
        print("aaaa");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }
}
