using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Ani : MonoBehaviour
{
    Player player;
    Animator animator;

    void Retry()
    {
        animator.SetBool("isGameOver", true);
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (player.Die == true)
        {
            Invoke("Retry", 1.2f);
        }
    }
}
