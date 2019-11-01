using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Player player;
    Quaternion Right = Quaternion.identity;
    //필요한 사운드 이름
    public string OpenDoorSound;
    float se = 0;
    static public GameObject self;
    GameManager GM;
    bool Once = true;
    Animation anim;

    void Start()
    {
        self = GameObject.Find("DoorAxis");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animation>();
    }

    void Open()
    {
        Right.eulerAngles = new Vector3(0, -90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Right, Time.deltaTime * 1.2f);
    }

    void Update()
    {
        if (GM.Clear == true)
        {
            Invoke("Open", 1.2f);
            if (se == 0)
            {
                SoundManager.instance.PlaySE(OpenDoorSound);
                se = 1;
            }
        }
        if (GM.Stage == 4 && Once == true)
        {
            Once = false;
            anim.Play("4Stage_Door");
        }
    }
}