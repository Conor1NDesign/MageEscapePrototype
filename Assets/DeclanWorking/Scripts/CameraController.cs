using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player1;
    Vector2 player1Pos;
    GameObject player2;
    Vector2 player2Pos;
    Vector3 camPos;
    Vector3 camPos2;
    Camera cam;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        cam = Camera.main;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        if (camPos != Vector3.zero)
        {

            Gizmos.DrawCube(new Vector3((player1Pos.x + player2Pos.x) / 2, 0, (player1Pos.y + player2Pos.y) / 2), Vector3.one);
        }
    }
    // Update is called once per frame
    void Update()
    {
        player1Pos = new Vector2(player1.transform.position.x, player1.transform.position.z);
        player2Pos = new Vector2(player2.transform.position.x, player2.transform.position.z);

        camPos = new Vector3((player1Pos.x + player2Pos.x) / 2, cam.transform.position.y - offset, (player1Pos.y + player2Pos.y) / 2);
        camPos2 = new Vector3((player1Pos.x + player2Pos.x) / 2, 0, (player1Pos.y + player2Pos.y) / 2);
        cam.transform.LookAt(camPos);


        transform.position = camPos2;

    }
}
