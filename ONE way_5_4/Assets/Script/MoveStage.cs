using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveStage : MonoBehaviour
{
    GameManager GM;
    int Stage = 1;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Stage = GM.Stage;
    }

    public void Movestage()
    {
        SceneManager.LoadScene("Stage_" + Stage.ToString());
    }
}
