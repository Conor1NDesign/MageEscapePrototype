using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{

    public bool melted;
    public float duration;
    float timeElapsed;
    Vector3 endpos;
    // Start is called before the first frame update
    void Start()
    {
        endpos = transform.position - new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (melted)
        {
            transform.position = Vector3.Lerp(transform.position, endpos, timeElapsed/duration);
            timeElapsed += Time.deltaTime;
        }
    }
}
