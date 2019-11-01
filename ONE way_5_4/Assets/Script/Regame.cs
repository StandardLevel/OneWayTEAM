using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Regame : MonoBehaviour
{
    Player player;
    GameManager GM;
    Animator animator;

    public void Retry00()
    {
        if(player.Die == true)
        {
            animator.SetBool("isGameOver", false);
            GM.Stage = GM.SaveStage;
            SceneManager.LoadScene("Main");
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player.Die == true)
        {
            animator.SetBool("isGameOver", true);
        }
    }
}
