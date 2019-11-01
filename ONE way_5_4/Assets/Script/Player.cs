using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject doorghost;
    public Animation anim;
    public Animation Door;
    public bool holeLook = false;
    public bool handleLook = false;
    public bool Block = false;
    public byte backon = 0;
    public float Speed;
    public float UDSpeed;
    public float RLSpeed;
    public float BTSpeed;
    public bool Die = false;
    bool stop = false;
    byte expand = 0;
    float btime = 1.5f;
    float Look1 = 0;
    float Look2 = 5;
    float Ypos;
    float Zrot;
    float move = 41.5f;
    bool UD;
    bool RL;
    bool BT;
    bool Halfon = false;
    float value;
    public GameObject DoorAxis;
    Quaternion Right = Quaternion.identity;
    float eular;
    float eular1=75;
    float Opposite = 1;
    public string DoorBlock;
    public string DoorImpact;
    GameManager GM;
    public bool first;
    public bool NoteOn;



    void Move()
    {
        GM.PlayerStop = false;
        transform.position += Vector3.forward * Time.deltaTime * Speed;
        if (UD)
        {
            transform.Translate(0, Time.deltaTime * UDSpeed, 0);
            if (transform.position.y >= Ypos + 0.1)
                UD = false;
        }
        if (!UD)
        {
            transform.Translate(0, Time.deltaTime * -UDSpeed, 0);
            if (transform.position.y <= Ypos - 0.05)
            {
                UD = true;
            }
        }
        if (RL)
        {
            transform.Rotate(0, 0, Time.deltaTime * RLSpeed);
            if (transform.rotation.z >= Zrot + 0.004)
                RL = false;
        }
        if (!RL)
        {
            transform.Rotate(0, 0, Time.deltaTime * -RLSpeed);
            if (transform.rotation.z <= Zrot - 0.004)
                RL = true;
        }
        if (transform.position.z >= 41.5f && stop == false)
        {
            stop = true;
            transform.position = new Vector3(0, 4.5f, 41.5f);
        }
    }
    void Breath()
    {
        if (BT)
            transform.Rotate(Time.deltaTime * -0.8f, 0, 0);
        if (!BT)
            transform.Rotate(Time.deltaTime * 0.6f, 0, 0);
    }

    void Shake()
    {
        transform.Translate(0, 0, 2 * Mathf.Sin(Time.deltaTime * 5f));
    }

    void Rotate()
    {
        if (Die == false && NoteOn == false)
        {
            if (Input.GetKeyDown(KeyCode.D) && backon == 0 && expand != 3 && GM.Clear == false && Halfon == false)
            {
                anim.Play("PlayerBack");
                backon = 2;
                Invoke("Backon", 0.7f);
            }
            if (Input.GetKeyDown(KeyCode.A) && backon == 1 && expand != 3 && GM.Clear == false && Halfon == false)
            {
                anim.Play("PlayerFront");
                backon = 2;
                Invoke("Backoff", 0.8f);
            }

            if (Input.GetKeyDown(KeyCode.D) && expand == 4)
            {
                anim.Play("PlayerHalfBack");
                expand = 6;
                Invoke("Expandfive", 0.5f);

            }
            if (Input.GetKeyDown(KeyCode.A) && expand == 5)
            {
                anim.Play("PlayerHalfFront");
                expand = 6;
                Invoke("Expandfour", 0.5f);
            }
        }
    }
    void Backon()
    {
        backon = 1;
    }
    void Backoff()
    {
        backon = 0;
    }
    void Expandzero()
    {
        expand = 0;
    }
    void Expandone()
    {
        expand = 1;
    }
    void Expandtwo()
    {
        expand = 2;
    }
    void Expandfour()
    {
        expand = 4;
    }
    void Expandfive()
    {
        expand = 5;
    }
    void HandleOut()
    {
        handleLook = false;
        anim.Play("PlayerHandleOut");
    }

    void GhostLook1()
    {
        if (transform.rotation.y > 0.95f && GM.Ghoston == true && GM.GhostType == 1)
        {
            Look1 += Time.deltaTime;
            if (Look1 > 1.0f && Die == false)
            {
                Die = true;
                anim.Play("Die");
            }
        }
    }
    void GhostLook2()
    {
        if (transform.rotation.y > 0.95f && GM.Ghoston == true && GM.GhostType == 2)
        {
            Look2 -= Time.deltaTime;
            if (Look2 > 0 && Input.GetKeyDown(KeyCode.A) && Die == false)
            {
                Die = true;
                anim.Play("Die");
            }
        }
    }
    void Zoomin()
    {
        if (Die == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 3.6f) && expand == 0 && backon == 0 && NoteOn == false)
                {
                    if (hit.collider.tag == "Handle")
                    {
                        handleLook = true;
                        anim.Play("PlayerHandleLook");
                        expand = 3;
                        Invoke("Expandone", 0.75f);
                    }
                    if (hit.collider.tag == "Lens")
                    {
                        holeLook = true;
                        anim.Play("PlayerHoleLook");
                        expand = 3;
                        Invoke("Expandtwo", 0.8f);
                    }
                    if (hit.collider.tag == "Save")
                    {

                        anim.Play("PlayerSave");
                        expand = 3;
                        Halfon = true;
                        Door.Play("DoorWave");
                        Invoke("Expandfour", 0.7f);
                        SoundManager.instance.PlaySE(DoorBlock);
                    }
                    if (hit.transform.tag == "Note" && hit.transform.gameObject.GetComponent<Note>().ClickOn == false)
                    {
                        hit.transform.gameObject.GetComponent<Note>().ClickOn = true;
                    }
                }
            }
            if (expand == 2 && backon == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                holeLook = false;
                anim.Play("PlayerHoleOut");
                expand = 3;
                Invoke("Expandzero", 1);
            }
            else if (expand == 4 && backon == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                Block = false;
                anim.Play("PlayerSaveOut");
                expand = 3;
                Halfon = false;
                Invoke("Expandzero", 0.75f);
            }
            else if (expand == 1 && backon == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                HandleOut();
                expand = 3;
                Invoke("Expandzero", 0.75f);
            }
        }
    }

    void OppositeDir()
    {
        Opposite = -1;
    }
    
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animation>();
        Door = GameObject.Find("Door").GetComponent<Animation>();
        Ypos = this.transform.position.y;
        Zrot = this.transform.rotation.z;
    }

    void MoveChange()
    {
        move = 60;
    }

    void Update()
    {
        if (transform.position.z < move)
        {
            Move();
        }
        else
        {
            GM.PlayerStop = true;
            Rotate();
        }
        GhostLook1();
        GhostLook2();
        Zoomin();
        if (GM.Ghoston == false)
        {
            Look1 = 0;
            Look2 = 5;
        }
        if (!holeLook)
        {
            Breath();
            btime -= Time.deltaTime;
            if (btime <= 0)
            {
                if (BT == true)
                {
                    btime = 1.3f;
                    BT = false;
                }
                else if (BT == false)
                {
                    btime = 0.8f;
                    BT = true;
                }
            }
        }
        if(GM.Clear == true && expand == 1)
        {
            Invoke("MoveChange", 2f);
            if (expand == 1)
            {
                expand = 3;
                Invoke("HandleOut", 0.5f);
            }
        }

        if (expand == 4 && GM.Ghoston2 == true || expand == 5 && GM.Ghoston2 == true)
        {
            doorghost = GameObject.Find("DoorGhost(Clone)");
            if (doorghost.transform.position.z <= 47)
            {
                SoundManager.instance.PlaySE(DoorImpact);               
                
                Door.Play("DoorSuperWave");
                Vector3 vec = new Vector3(0, 0, 0.01f * Mathf.Cos(value += 30 * Time.deltaTime));
                this.transform.position += vec;
            }
            Block = true;
        }

        if (transform.position.z>48)
        {
            eular += Time.deltaTime * 300 * Opposite;
            transform.rotation = Quaternion.Euler(0, Mathf.Clamp(eular, 0, 170), 0);

            Invoke("OppositeDir", 1f);  
        }
    }
}