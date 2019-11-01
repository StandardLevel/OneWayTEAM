using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnd : MonoBehaviour
{
    float eular;
    float eular1 = 75;
   
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (10 > transform.position.z)
        {
            eular1 += Time.deltaTime * 300 * -1;
            transform.rotation = Quaternion.Euler(0, Mathf.Clamp(eular1, 0, 170), 0);

        }
    }
}
