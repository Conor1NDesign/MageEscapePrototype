using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    List<GameObject> spellBook;
    public GameObject Player1CheckPoint;
    public GameObject Player2CheckPoint;
    public GameObject redLight;
    public GameObject blueLight;

    public List<GameObject> spellbookCheckPoints;
    public List<GameObject> BlackList;
    int spellbookCounter = 0;

    // Start is called before the first frame update
    void Start()
    {

        spellBook = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.name == "Player 1")
            {
                other.GetComponent<PlayerController>().currentSpawnPoint = Player1CheckPoint.transform;
                blueLight.SetActive(true);
            }
            else
            { 
                other.GetComponent<PlayerController>().currentSpawnPoint = Player2CheckPoint.transform;
                redLight.SetActive(true);
            }
        }
        else if (other.CompareTag("Spellbook") && !BlackList.Contains(other.gameObject))
        {
            if (!spellBook.Contains(other.gameObject))
            {
                try
                {
                    other.gameObject.GetComponent<SpellbookController>().spellbookRespawnPoint = spellbookCheckPoints[spellbookCounter].transform;
                    BlackList.Add(other.gameObject);
                    spellbookCounter++;
                }
                catch
                {
                    spellbookCounter= 0;
                    other.gameObject.GetComponent<SpellbookController>().spellbookRespawnPoint = spellbookCheckPoints[spellbookCounter].transform;
                    BlackList.Add(other.gameObject);
                    spellbookCounter++;
                }
            }
        }
    }
}
