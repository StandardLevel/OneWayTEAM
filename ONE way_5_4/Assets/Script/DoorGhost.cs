using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGhost : MonoBehaviour
{
    DoorGhostSpawn SpawnPosition;
    public float DestroyTime;
    float UpdateTime;
    public float Speed;
    Player player;
    GameManager GM;
   

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (transform.position.z > 46.5f)
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        if (transform.position.z <= 47)
        {
            if (player.Block == false)
            {
                player.anim.Play("Die");
                player.Die = true;
            }
            else if (player.Block == true)
            {
                UpdateTime += Time.deltaTime;
                if (UpdateTime > DestroyTime)
                {
                    GM.Ghoston2 = false;
                    Destroy(this.gameObject);
                }
            }
        }
        if (GM.Clear == true)
        {
            GM.Ghoston2 = false;
            Destroy(this.gameObject);
        }
    }
}
