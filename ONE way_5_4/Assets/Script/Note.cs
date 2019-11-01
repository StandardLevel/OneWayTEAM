using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool ClickOn = false; 
    GameObject player;
    bool first = false;
    Vector3 MousePos;
    Vector3 Temp = new Vector3(0, 0, 0);
    float XTemp;
    float YTemp;
    bool PosCheck = false;
    Vector3 FirstPos;
    Vector3 FirstRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        FirstPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        FirstRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickOn == true)
        {
            if (first == false) // 클릭한후 처음 한번만
            {
                player.GetComponent<Player>().NoteOn = true;
                transform.position = new Vector3(0, player.transform.position.y - 1.5f, player.transform.position.z + 1f);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Temp = new Vector3(0, 0, 0);
                MousePos = new Vector3(0, 0, 0);
                first = true;
            }
            if (transform.position.y <= 4.5)
            {
                transform.Translate(0, Time.deltaTime * 2f, 0, Space.World);
                if(transform.position.y > 4.5)
                {
                    transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
                }
            }

            if (transform.position.y == 4.5)
            {
                if (Input.GetMouseButton(0)) // 현재 프레임의 마우스위치
                {
                    MousePos = Input.mousePosition;
                }

                //transform.rotation = Quaternion.Euler(XTemp - Mathf.Abs(Temp.y - MousePos.y), YTemp + Temp.x - MousePos.x, 0);

                if (PosCheck == true) // 이전프레임의 마우스위치 값과 현재프레임의 마우스 위치값에 둘다 값을 저장했을때 (현재값만 저장되는 첫 프레임에는 실행 안됨)
                {
                    transform.Rotate(new Vector3(-(Temp.y - MousePos.y), (Temp.x - MousePos.x), 0) * 10 * Time.deltaTime, Space.World); //현재 위치 - 이전 위치 만큼 움직임
                }

                if (Input.GetMouseButton(0)) // 이전 프레임의 마우스 위치
                {
                    Temp = Input.mousePosition; 
                    PosCheck = true; //이전위치와 현재위치값이 둘다 저장완료 되었음
                }

                if (Input.GetMouseButtonUp(0))
                {
                    PosCheck = false;
                    XTemp = transform.localEulerAngles.x;
                    YTemp = transform.localEulerAngles.y;
                    Temp = new Vector3(0, 0, 0);
                    MousePos = new Vector3(0, 0, 0);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            player.GetComponent<Player>().NoteOn = false;
            first = false;
            ClickOn = false;
            transform.position = FirstPos;
            transform.rotation = Quaternion.Euler(FirstRotation);
        }
    }
}
