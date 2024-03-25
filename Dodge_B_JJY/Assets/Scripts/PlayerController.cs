using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody;       //플레이어 오브젝트에 있는 RigidBody 컴포넌트를 연결하기 위한 변수
    public float speed = 8f;                //이동 속도 수치 값을 저장하는 변수

    // Start is called before the first frame update
    void Start()
    {
        //playerRigidBody = GetComponent<Rigidbody>();    //시작하면서 자동으로 컴포넌트를 할당함
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidBody.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidBody.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidBody.AddForce(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidBody.AddForce(-speed, 0, 0);
        }
    }


    public void Die()       //플레이어 캐릭터가 사망시 호출되고
    {
        gameObject.SetActive(false);
    }
}   
