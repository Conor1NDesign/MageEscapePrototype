using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightObject;

    public float minIntensity;
    public float maxIntensity;

    public float updateSpeed;
    private float updateCount;

    private void Awake()
    {
        lightObject = this.gameObject.GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lightObject.intensity = maxIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateCount > updateSpeed)
        {
            updateCount = 0f;
            lightObject.intensity = Random.Range(minIntensity, maxIntensity);
        }

        updateCount += Time.deltaTime;
    }
}
