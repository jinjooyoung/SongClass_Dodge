using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody;       //�÷��̾� ������Ʈ�� �ִ� RigidBody ������Ʈ�� �����ϱ� ���� ����
    public float speed = 8f;                //�̵� �ӵ� ��ġ ���� �����ϴ� ����

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();    //�����ϸ鼭 �ڵ����� ���� ������Ʈ���� ������ٵ� ������Ʈ�� ã�Ƽ� �÷��̾� ������ٵ� �Ҵ���
        //�ٵ� �� �ڵ� �Ҵ�ǰ��ϴ� �� �Լ��� �־�� �ϴ°���? �׳� ������Ʈ���� ������ѳ����� �Ǵ°� �ƴѰ�
        //���� ã�Ƽ� ������ �ֱ� �����Ƽ� �Լ� �ϳ��� �����ϴ°ǰ�
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidBody.AddForce(0, 0, speed);  //AddForce�� ������ ���ӵ��� ���ܼ� ������ ����
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

        float xInput = Input.GetAxis("Horizontal");     //����Ű�� wasd�� ���� -1, 0 ,1 �� �ϳ��� ����
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;      //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float zSpeed = zInput * speed;      //������ �Է¹��� -1, 0, 1�� speed�� ���ؼ� �������� �̵��ӵ��� output

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);      //����3 �ӵ��� (xSpeed, 0 ,zSpeed)�� ����
        playerRigidBody.velocity = newVelocity;                     //������ٵ��� �ӵ��� newVelocity �Ҵ�
    }


    public void Die()       //�÷��̾� ĳ���Ͱ� ����� ȣ��ǰ�
    {
        gameObject.SetActive(false);        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ

        GameManager gameManager = FindObjectOfType<GameManager>();      // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������

        gameManager.EndGame();      // Gamemenager Ÿ���� ������Ʈ�� ������ �ִ� EndGame() �ż��� ����
    }
}   
