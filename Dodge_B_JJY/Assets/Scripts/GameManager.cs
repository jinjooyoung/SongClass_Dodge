using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     // 게임오버 시 활성화 할 텍스트 게임 오브젝트
    public Text timeText;               // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;             // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime;          // 생존 시간
    bool isGamover;                     // 게임 오버 상태 (true == 게임 오버상태)

    public AudioSource playerDie;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGamover = false;

        playerDie = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamover)
        {
            surviveTime += Time.deltaTime;          // 생존 시간 갱신
            // 댕신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time : " + (int)surviveTime;          // 강제 변환함으로써 소수점을 없애고 자연수 초 단위로 볼 수 있게함
        }
        else
        {
            gameoverText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge_Scene");      // 씬을 다시 로드함. 재로드
            }
        }
    }

    public void EndGame()
    {
        isGamover = true;               // 현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true);       // 게임오버 텍스트 게임 오브젝트 활성화

        playerDie.Play();

        float bestTime = PlayerPrefs.GetFloat("Best_Time");     // bestTime 키로 저장된 이전까지의 최고 기록 가져오기

        if (surviveTime > bestTime)     // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        {
            bestTime = surviveTime;     // 최고 기록 값을 현재 생존 시간 값으로 변경
            PlayerPrefs.SetFloat("Best_Time", bestTime);        // 변경된 최고 기록을 bestTime 키로 저장
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}
