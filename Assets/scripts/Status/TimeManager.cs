using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float timer;
    public bool TimerActive;

    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
        timer = 300;
        TimerActive = true;
    }

    void Update()
    {
        if(TimerActive && timer > 0) timer -= Time.deltaTime;
        if(timer <= 0) timerText.text = "0";
        else timerText.text = (int)timer + "";

        if (timer < -2) SceneManager.LoadScene("EndScene");
    }
}
