using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[Header("Player Position")]
	[Tooltip("Player one's transform, used to get the position that the camera should be")]
	public Transform playerOneTransform;
	[Tooltip("Player two's transform")]
	public Transform playerTwoTransform;

	[Header("Camera Variables")]
	[Tooltip("The camera's transform")]
	public Transform cameraTransform;
	[Tooltip("The minimum distance from the players")]
	public float minDistance;
	[Tooltip("The camera's normal angle")]
	public Quaternion cameraAngle;
	[Tooltip("The position to move to for overview mode")]
	public Transform overviewPosition;
	[Tooltip("Whether the camera is in overview mode")]
	public bool overviewMode = false;
	[Tooltip("Progress towards the overview mode position")]
	public float overviewProgress = 0.0f;


    void Update()
    {
		if (overviewMode && overviewProgress < 1.0f)
			overviewProgress += Time.deltaTime;
		else if (!overviewMode && overviewProgress > 0.0f)
			overviewProgress -= Time.deltaTime;
		
		if (overviewProgress > 1.0f)
			overviewProgress = 1.0f;
		if (overviewProgress < 0.0f)
			overviewProgress = 0.0f;

        transform.position = (playerOneTransform.position + playerTwoTransform.position) / 2;

		Vector3 normalCameraPos = -cameraTransform.forward * Math.Max((playerOneTransform.position - playerTwoTransform.position).magnitude, minDistance);

		// Set the local position of the camera
		// This should be between the overview position (which is global) and observing the players if necessary
		cameraTransform.localPosition = normalCameraPos * (1.0f - overviewProgress) + (overviewPosition.position - transform.position) * overviewProgress;
		cameraTransform.rotation = Quaternion.Slerp(cameraAngle, overviewPosition.rotation, overviewProgress);
    }
}
