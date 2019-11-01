using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHOST_2 : MonoBehaviour
{
    public float SPEED = 3.0f;
    Player player;
    Animation Ani;
    GameObject Ghost;
    Animator animator;
    public float Destoryspeed = 5f;
    Vector3 zero = new Vector3(0, 0, 0);
    GameManager GM;


    IEnumerator SPEEDstart()
    {
        SPEED = 0.0f;
        yield return new WaitForSeconds(Destoryspeed);
        if (player.Die == false)
        {
            Destroy(Ghost);
            GM.Ghoston = false;
        }
        SPEED = 3.0f;
    }

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.GhostType = 2;
        Ghost = GameObject.Find("Ghost2(Clone)");
        player = GameObject.Find("Player").GetComponent<Player>();
        Ani = player.GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.transform.position.z - 2.5f < transform.position.z && player.Die == false)
        {
            player.Die = true;
            Ani.Play("Die");
        }

        
            transform.Translate(0, 0, SPEED * Time.deltaTime);
        Vector3 vec = new Vector3(player.transform.position.x - this.transform.position.x, 0, player.transform.position.z - this.transform.position.z);
       
        transform.rotation = Quaternion.LookRotation(vec, zero);

        if (player.backon == 1)
            animator.SetBool("isLook", true);

        if (player.Die == true)
        {
            SPEED = 0;
            float stop = player.transform.position.z - 2.5f;
            animator.SetBool("isAttack", true);
            transform.position = new Vector3( 0, 0.1f, stop);
        }

        if (player.backon == 1 && GM.Ghoston == true)
        {
            StartCoroutine("SPEEDstart");
        }

        if (GM.Clear == true)
            Destroy(Ghost);
    }
}


