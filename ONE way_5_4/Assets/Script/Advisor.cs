using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor : MonoBehaviour
{
    Animator animator;

    void DoorOpen()
    {
        animator.SetBool("isOpenDoor", true);
        Invoke("Walk", 3);
    }

    void Walk()
    {
        animator.SetBool("isWalking", true);
        Invoke("Destroy", 5);
    }

    void Move()
    {
        transform.Translate(0, 0, Time.deltaTime * 2);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        Invoke("DoorOpen", 1);
    }

    void Update()
    {
        Invoke("Move", 4);
    }
}
