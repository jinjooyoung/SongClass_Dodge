using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;            //ź���� �̵� �ӷ�
    private Rigidbody bulletRigidBody;  //�̵��� ����� ������ٵ� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();            //������ٵ� �ڵ��Ҵ�
        bulletRigidBody.velocity = transform.forward * speed;   //��ü�� ������ ��ü�� ���� ���� z�� ����. ��ü���� �������� �̵�
        Destroy(gameObject, 3f);        //3�ʵڿ� �����
    }

    private void OnTriggerEnter(Collider other)     //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �ż���
    {
        if (other.tag == "Player")      //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        {
            PlayerController playerController = other.GetComponent<PlayerController>();     //���� ���� ������Ʈ���� PlayerController ������Ʈ ��������

            if (playerController != null)       //�������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            {
                playerController.Die();     //���� PlayerController ������Ʈ�� Die() �ż��� ����
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
