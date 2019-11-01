using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkillCheck : MonoBehaviour
{
    Player player;
    public bool Exist = false;
    public GameObject obj;
    float spawntimeMax;
    float spawntime;
    public float minimum;
    public float maximum;
    GameManager GM;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spawntimeMax = Random.Range(minimum, maximum);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (GM.PlayerStop == true && Exist == false && player.handleLook == true)
            spawntime += Time.deltaTime;

        if(spawntimeMax <= spawntime)
        {
            Instantiate(obj);
            spawntimeMax = Random.Range(minimum, maximum);
            spawntime = 0;
            Exist = true;
        }
    }
}
