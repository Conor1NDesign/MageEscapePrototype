﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{

    public bool melted;
    public float duration;
    float timeElapsed;
    Vector3 endScale;
    
    void Start()
    {
        endScale = new Vector3(1, 0.2f, 1);
    }

    void Update()
    {
        if (melted)
        {
            transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), endScale, timeElapsed/duration);
            timeElapsed += Time.deltaTime;
        }

        if (timeElapsed > duration)
        {
            melted = false;
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
        }
    }
}
