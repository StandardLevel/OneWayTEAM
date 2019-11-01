using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbreathe : MonoBehaviour
{
    public bool Die = false;
    Player player;
    float diesound = 0;
 
    void breathe()
    {
        if (player.Die == false)
        {
            SoundManager.instance.audioSourceBgm.Play();
            SoundManager.instance.audioSourceBgm.loop = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        breathe();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Die == true && diesound == 0)
        {
            SoundManager.instance.audioSourceBgm.Stop();
            Debug.Log("멈춤");
            diesound = 1;
        }
    }
}
