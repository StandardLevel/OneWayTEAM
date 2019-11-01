using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject RE;
    public byte GhostType = 0;
    public bool PlayerStop = false;
    public bool Clear = false;
    public bool Ghoston = false;
    public bool Ghoston2 = false;
    public int Stage = 1;
    public int SaveStage = 1;

    void MoveScene()
    {
        if (Clear == true)
        {
            Clear = false;
            Stage++;
            SceneManager.LoadScene("Stage_"+ Stage.ToString());
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.Find("Regame(Clone)") == null && SceneManager.GetActiveScene().name != "Main")
        {
            Instantiate(RE);
        }
        Ghoston = false;
        Ghoston2 = false;
        Clear = false;


        SaveStage = Stage;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Clear = true;
        }

        if (Clear == true)
        {
            Ghoston = false;
           
            Invoke("MoveScene", 5f);
        }
    }
}
