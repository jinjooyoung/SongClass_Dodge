using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameover_text;
    public Text time_text;
    public Text record_text;

    private float survive_time;
    bool is_gamover;

    // Start is called before the first frame update
    void Start()
    {
        survive_time = 0;
        is_gamover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_gamover)
        {
            survive_time += Time.deltaTime;
            time_text.text = "Time" + (int) survive_time;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge_Scene");
            }
        }
    }

    public void EndGame()
    {
        is_gamover = true;
        gameover_text.SetActive(true);

        float best_time = PlayerPrefs.GetFloat("Best_Time");

        if (survive_time > best_time)
        {
            best_time = survive_time;
            PlayerPrefs.SetFloat("Best_Time", best_time);
        }

        record_text.text = "Best Time : " + (int)best_time;
    }
}
