using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGhostSpawn : MonoBehaviour
{
    Player Player;
    Gauge gauge;
    GameManager GM;
    GameObject Ghostinstance;
    float SpawnTime = 1;
    public GameObject DoorGhost;

    void SpawnCountDown()
    {
        if (GM.Ghoston2 == false && gauge.gauge >= 30 && Player.holeLook == false)
        {
            
            SpawnTime -= Time.deltaTime;
            Debug.Log(SpawnTime);
        }
    }

    void Stage4()
    {
        if (SpawnTime < 0)
        {
            Ghostinstance = Instantiate(DoorGhost, transform.position, DoorGhost.transform.rotation);
            GM.Ghoston2 = true;
            SpawnTime = Random.Range(10, 20);
        }
    }

    void Stage5()
    {
        if (SpawnTime < 0)
        {
            Ghostinstance = Instantiate(DoorGhost, transform.position, DoorGhost.transform.rotation);
            GM.Ghoston2 = true;
            SpawnTime = Random.Range(35, 55);
        }
    }

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        SpawnTime = Random.Range(10, 20);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        gauge = GameObject.Find("gauge").GetComponent<Gauge>();
    }

    void Update()
    {
        SpawnCountDown();
        switch (GM.Stage)
        {
            case 4:
                Stage4();
                break;
            case 5:
                Stage5();
                break;
        }
    }
}
