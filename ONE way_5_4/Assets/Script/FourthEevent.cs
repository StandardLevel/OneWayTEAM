using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthEevent : MonoBehaviour
{
   public GameObject player;

    IEnumerator PlayerOff()
    {
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        player.GetComponent<Playerbreathe>().enabled = false;
        yield return new WaitForSeconds(10f);
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        player.GetComponent<Playerbreathe>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayerOff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
