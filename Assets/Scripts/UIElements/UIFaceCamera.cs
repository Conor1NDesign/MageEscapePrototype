using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFaceCamera : MonoBehaviour
{
    public Transform cameraToFace;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        cameraToFace = Camera.main.transform;
        canvas = gameObject.GetComponent<Canvas>();
        canvas.worldCamera = cameraToFace.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraToFace);
    }
}
