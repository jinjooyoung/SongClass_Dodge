using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;        //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;       //최소 생성 주기
    public float spawnRateMax = 3.0f;         //최대 생성 주기

    private Transform target;               //발사할 대상
    private float spawnRate;                //생성 주기
    private float timeAfterSpawn;           //최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;                                        //최근 생성 이루의 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);       //탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform;    //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
    }

    // Update is called once per frame
    void Update()
    {
        //타임애프터스폰 시간 갱신(업데이트때마다 흘러간 시간을 누적 합산)
        timeAfterSpawn += Time.deltaTime;
        //랜덤값으로 결정된 탄환 생성주기보다 마지막 탄환 생성 이후 흐른 시간이 커지면 아래 if 실행
        if (timeAfterSpawn >= spawnRate)
        {
            //마지막 탄환 발사 이후 시간을 0으로 돌리고
            timeAfterSpawn = 0;

            //탄환을 생성하고 캐릭터(타겟)을 바라보도록 방향 전환
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            //다음 탄환 생성주기 값을 위에서 설정한 0.5 ~ 3.0 사이의 랜덤값으로 결정작업 진행
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
