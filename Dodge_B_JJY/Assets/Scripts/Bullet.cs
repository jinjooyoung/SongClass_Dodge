using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;            //탄알의 이동 속력
    private Rigidbody bulletRigidBody;  //이동에 사용할 리지드바디 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();            //리지드바디 자동할당
        bulletRigidBody.velocity = transform.forward * speed;   //물체를 돌려도 물체가 갖는 로컬 z축 방향. 물체기준 정면으로 이동
        Destroy(gameObject, 3f);        //3초뒤에 사라짐
    }

    private void OnTriggerEnter(Collider other)     //트리거 충돌 시 자동으로 실행되는 매서드
    {
        if (other.tag == "Player")      //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        {
            PlayerController playerController = other.GetComponent<PlayerController>();     //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기

            if (playerController != null)       //상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            {
                playerController.Die();     //상대방 PlayerController 컴포넌트의 Die() 매서드 실행
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
