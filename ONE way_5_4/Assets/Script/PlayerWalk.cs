using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    Player player;
    private AudioSource Walksound;
    public AudioClip Walk;
    GameManager GM;
    

    void playermovesound (AudioClip Clip , AudioSource audioplayer)
    {
 
        if (GM.Clear == false)
        {
            audioplayer.Play();
            audioplayer.loop = true;

        }



    }
    

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        Walksound = GetComponent<AudioSource>();
        playermovesound(Walk, Walksound);
    }




    // Update is called once per frame
    void Update()
    {
        if (GM.PlayerStop == true/* && GameManager.Clear == false*/)
        {
            Walksound.Pause(); // 일시정지
            Walksound.loop = false;
        }
        if (GM.PlayerStop == false /*&& GameManager.Clear == true*/)
        {
            Walksound.UnPause(); // 다시 재생
            Walksound.loop = true;
            
        }


    }

}

