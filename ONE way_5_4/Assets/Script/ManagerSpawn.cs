using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public GameObject GM;
    public GameObject SM;
    GameObject GMC;
    GameObject SMC;

    void Awake()
    {
        if (GameObject.Find("GameManager") == null)
        {
            GMC = Instantiate(GM);
            GMC.name = "GameManager";
        }
        if (GameObject.Find("SoundManager") == null)
        {
            SMC = Instantiate(SM);
            SMC.name = "SoundManager";
        }
    }
}
