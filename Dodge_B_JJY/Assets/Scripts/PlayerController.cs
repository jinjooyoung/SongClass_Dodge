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
        playerRigidBody = GetComponent<Rigidbody>();    //시작하면서 자동으로 게임 오브젝트에서 리지드바디 컴포넌트를 찾아서 플레이어 리지드바디에 할당함
        //근데 왜 자동 할당되게하는 이 함수가 있어야 하는거지? 그냥 컴포넌트에서 연결시켜놓으면 되는거 아닌가
        //굳이 찾아서 일일히 넣기 귀찮아서 함수 하나로 구현하는건가
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidBody.AddForce(0, 0, speed);  //AddForce는 서서히 가속도가 생겨서 관성이 있음
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
        }*/

        float xInput = Input.GetAxis("Horizontal");     //방향키나 wasd의 값을 -1, 0 ,1 중 하나로 받음
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;      //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float zSpeed = zInput * speed;      //위에서 입력받은 -1, 0, 1을 speed와 곱해서 실질적인 이동속도를 output

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);      //벡터3 속도를 (xSpeed, 0 ,zSpeed)로 생성
        playerRigidBody.velocity = newVelocity;                     //리지드바디의 속도에 newVelocity 할당
    }


    public void Die()       //플레이어 캐릭터가 사망시 호출되고
    {
        gameObject.SetActive(false);        // 자신의 게임 오브젝트를 비활성화

        GameManager gameManager = FindObjectOfType<GameManager>();      // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기

        gameManager.EndGame();      // Gamemenager 타입의 오브젝트가 가지고 있던 EndGame() 매서드 실행
    }
}   
