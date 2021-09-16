using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    List<GameObject> players;
    public GameObject checkPoint1;
    public GameObject checkPoint2;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 2)
        {
            players[0].GetComponent<PlayerController>().currentSpawnPoint = checkPoint1.transform;
            players[1].GetComponent<PlayerController>().currentSpawnPoint = checkPoint2.transform;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!players.Contains(other.gameObject))
            {
                players.Add(other.gameObject);
            }
        }
    }
}
