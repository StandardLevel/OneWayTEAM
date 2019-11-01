using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourthAni : MonoBehaviour
{
    Animation Ani;
    bool Stop = false;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 10f && !Stop)
        {
            Ani.Play("4Stage");
            Stop = true;
        }
    }
}
