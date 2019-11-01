using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    Light theLight;
    float currentIntensity;
    bool ok = false;
    GameManager GM;

    void LightUp()
    {
        theLight.intensity = 1.5f;
    }

    void LightOff()
    {
        theLight.intensity = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        theLight = GetComponent<Light>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    IEnumerator LightFlick()
    {
        yield return new WaitForSeconds(2f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.1f);
        theLight.intensity = 1.5f;
        yield return new WaitForSeconds(0.3f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 1.5f;
        yield return new WaitForSeconds(1f);
        theLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.Clear == true&&!ok)
        {
             StartCoroutine("LightFlick");
            
            ok = true;
         
          //  theLight.intensity = 0f;
        }
    }
}
