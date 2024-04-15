using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;        //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;       //�ּ� ���� �ֱ�
    public float spawnRateMax = 3.0f;         //�ִ� ���� �ֱ�

    private Transform target;               //�߻��� ���
    private float spawnRate;                //���� �ֱ�
    private float timeAfterSpawn;           //�ֱ� ���� �������� ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;                                        //�ֱ� ���� �̷��� ���� �ð��� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);       //ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        target = FindObjectOfType<PlayerController>().transform;    //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ�Ӿ����ͽ��� �ð� ����(������Ʈ������ �귯�� �ð��� ���� �ջ�)
        timeAfterSpawn += Time.deltaTime;
        //���������� ������ źȯ �����ֱ⺸�� ������ źȯ ���� ���� �帥 �ð��� Ŀ���� �Ʒ� if ����
        if (timeAfterSpawn >= spawnRate)
        {
            //������ źȯ �߻� ���� �ð��� 0���� ������
            timeAfterSpawn = 0;

            //źȯ�� �����ϰ� ĳ����(Ÿ��)�� �ٶ󺸵��� ���� ��ȯ
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            //���� źȯ �����ֱ� ���� ������ ������ 0.5 ~ 3.0 ������ ���������� �����۾� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
