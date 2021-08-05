using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject Platform;
    Vector3 startPos;
    [SerializeField]
    private GameObject endPos = null;

    [Tooltip("How many frames it takes to get from point A to point B")]
    public int speed = 200;
    [Tooltip("Moving back and forward when activated")]
    public bool oscillating;
    int elapsedFrames = 0;
    bool ToEnd = true;
    public int numberOfSwitches;
    public int numberOfActiveSwitches;
    public float aa;

    private void OnDrawGizmosSelected()
    {
        if (startPos == Vector3.zero)
        {
            Gizmos.DrawLine(Platform.transform.position, endPos.transform.position);
        }
        else
        {
            Gizmos.DrawLine(startPos, endPos.transform.position);
        }
        print(startPos);
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = Platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Actived();

        //Platform.transform.position = Vector3.Lerp(endPos.transform.position, startPos, speed /10* Time.deltaTime);

    }

    bool moving;
    float counter;
    float interpolationRatio;
    private void FixedUpdate()
    {

        if (oscillating)
        {
            if (moving)
            {

                counter += Time.deltaTime;
                if (counter > 1)
                {
                    if (Vector3.Distance(Platform.transform.position, endPos.transform.position) <= 0.01f && ToEnd)
                    {
                        aa = Vector3.Distance(Platform.transform.position, endPos.transform.position);
                        counter = 0;
                        elapsedFrames = 0;
                        ToEnd = false;
                    }
                    else if (Vector3.Distance(Platform.transform.position, startPos) <= 0.01f && !ToEnd)
                    {
                        aa = Vector3.Distance(Platform.transform.position, startPos);
                        counter = 0;
                        elapsedFrames = 0;
                        ToEnd = true;
                    }
                }
                interpolationRatio = (float)elapsedFrames / speed;
                if (ToEnd)
                {
                    Platform.transform.position = Vector3.Lerp(startPos, endPos.transform.position, interpolationRatio);
                }
                else if (!ToEnd)
                {
                    Platform.transform.position = Vector3.Lerp(endPos.transform.position, startPos, interpolationRatio);
                }

                elapsedFrames = (elapsedFrames + 1) % (speed + 1);
            }

        }
        else
        {
            if (moving)
            {
                print("a");
                if (Vector3.Distance(Platform.transform.position, endPos.transform.position) <= 0.01f && ToEnd)
                {
                    aa = Vector3.Distance(Platform.transform.position, endPos.transform.position);
                    counter = 0;
                    elapsedFrames = 0;
                    ToEnd = false;
                }
                else if (Vector3.Distance(Platform.transform.position, startPos) <= 0.01f && !ToEnd)
                {
                    aa = Vector3.Distance(Platform.transform.position, startPos);
                    counter = 0;
                    elapsedFrames = 0;
                    ToEnd = true;
                }
                interpolationRatio = (float)elapsedFrames / speed;
                if (ToEnd)
                {
                    Platform.transform.position = Vector3.Lerp(startPos, endPos.transform.position, interpolationRatio);
                }
                elapsedFrames = (elapsedFrames + 1) % (speed + 1);
            }
        }

    }


    public void Actived()
    {

        if (numberOfSwitches == numberOfActiveSwitches)
            moving = true;
    }

    public void Deactived()
    {

        moving = false;
        if (numberOfSwitches == numberOfActiveSwitches)
            moving = true;
    }



}
