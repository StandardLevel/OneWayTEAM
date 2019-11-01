using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    Light theLight;
    float targetIntensity;
    float currentIntensity;

    void Start()
    {
        theLight = GetComponent<Light>();
        currentIntensity = theLight.intensity;
        targetIntensity = Random.Range(0.4f, 1f);
    }

    void Update()
    {
        if(Mathf.Abs(targetIntensity - currentIntensity) >= 0.01)
        {
            if (targetIntensity - currentIntensity >= 0)
                currentIntensity += Time.deltaTime * 3f;
            else
                currentIntensity -= Time.deltaTime * 3f;

            theLight.intensity = currentIntensity;
            theLight.range = currentIntensity + 20;
        }
        else
        {
            targetIntensity = Random.Range(0.4f, 1f);
        }
    }
}
