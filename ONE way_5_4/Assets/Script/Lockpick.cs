using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick : MonoBehaviour
{
    Player player;
    MeshRenderer mesh;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (player.handleLook == true)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
    }
}
