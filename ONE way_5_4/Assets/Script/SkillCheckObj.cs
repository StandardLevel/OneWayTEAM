using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckObj : MonoBehaviour
{
    bool dir = true;
    bool XY;
    float max = 1.5f;
    float min = 1.0f;
    public float speed;
    void Awake()
    {
        if (this.name == "X")
        {
            speed = Random.Range(max, min);
        }
    }

    void Moving()
    {
        if (XY == true)
        {
            if (dir == true)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (dir == false)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        if (XY == false)
        {
            if (dir == true)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (dir == false)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
        }
        if (transform.localPosition.x <= -0.37f || transform.localPosition.y <= -0.37f)
        {
            dir = false;
        }
        else if (transform.localPosition.x >= 0.37f || transform.localPosition.y >= 0.37f)
        {
            dir = true;
        }
    }

    void Stop()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            speed = 0;
        }
    }

    void Start()
    {
        if(this.name == "X")
        {
            XY = true;
        }
        if(this.name == "Y")
        {
            speed = GameObject.Find("X").GetComponent<SkillCheckObj>().speed;
            XY = false;
        }
    }

    void Update()
    {
        Moving();
        Stop();
    }
}
