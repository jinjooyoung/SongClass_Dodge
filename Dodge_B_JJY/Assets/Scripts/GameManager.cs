using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     // ���ӿ��� �� Ȱ��ȭ �� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText;               // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;             // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime;          // ���� �ð�
    bool isGamover;                     // ���� ���� ���� (true == ���� ��������)

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
            surviveTime += Time.deltaTime;          // ���� �ð� ����
            // ����� ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)surviveTime;          // ���� ��ȯ�����ν� �Ҽ����� ���ְ� �ڿ��� �� ������ �� �� �ְ���
        }
        else
        {
            gameoverText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge_Scene");      // ���� �ٽ� �ε���. ��ε�
            }
        }
    }

    public void EndGame()
    {
        isGamover = true;               // ���� ���¸� ���ӿ��� ���·� ��ȯ
        gameoverText.SetActive(true);       // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ

        playerDie.Play();

        float bestTime = PlayerPrefs.GetFloat("Best_Time");     // bestTime Ű�� ����� ���������� �ְ� ��� ��������

        if (surviveTime > bestTime)     // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        {
            bestTime = surviveTime;     // �ְ� ��� ���� ���� ���� �ð� ������ ����
            PlayerPrefs.SetFloat("Best_Time", bestTime);        // ����� �ְ� ����� bestTime Ű�� ����
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}
