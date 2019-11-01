using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    Player player;
    public float gauge = 0;
    Image img;
    GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        img = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (GM.PlayerStop == true && player.handleLook == true && player.backon == 0 && player.Die == false)
        {
            gauge += (Time.deltaTime);
        }else if(gauge > 0)
        {
            gauge -= (Time.deltaTime * 1.5f);
        }
        img.fillAmount = gauge / 100f;
        if (gauge >= 100)
        {
            GM.Clear = true;
            Destroy(GameObject.Find("gauge"));
        }
        if (gauge < 0)
        {
            gauge = 0;
        }
    }
}