using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    Player player;
    bool click;
    Gauge Gauge;
    SpawnSkillCheck spawn;
    bool trigger = false;
    [SerializeField]
    private string PSound;
    [SerializeField]
    private string GSound;
    GameManager GM;

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Range")
        {
            trigger = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        trigger = false;
    }

    void Delete()
    {
        Destroy(GameObject.Find("SkillCheck(Clone)"));
        spawn.Exist = false;
    }

    void Judgment()
    {
        if (trigger == true)
        {
            if (this.name == "Perfect")
            {
                SoundManager.instance.PlaySE(PSound);
                Debug.Log("Perfect");
                Gauge.gauge += 5;
            }
            else if (this.name == "Good")
            {
                SoundManager.instance.PlaySE(GSound);
                Debug.Log("Good");
                Gauge.gauge += 5;
            }
        }
        else if (trigger == false && Gauge.gauge > 0 && this.name == "Good")
        {
            Debug.Log("Fail");
            Gauge.gauge -= 5;
        }
    }

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        spawn = GameObject.Find("SpawnSkillCheck").GetComponent<SpawnSkillCheck>();
        Gauge = GameObject.Find("gauge").GetComponent<Gauge>();
    }

    void Update()
    {
        if (GM.PlayerStop == true && player.handleLook == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && spawn.Exist == true && click == false)
            {
                click = true;
                Invoke("Judgment", 0.1f);
                Invoke("Delete", 0.5f);
            }
        }
        if (player.handleLook == false)
            Delete();

        if (GM.Clear == true)
            Delete();
    }
}
