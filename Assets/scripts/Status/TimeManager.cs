using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timer;
    public bool TimerActive;

    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
        timer = 180;
        TimerActive = false;
    }

    void Update()
    {
        if(TimerActive && timer > 0) timer -= Time.deltaTime;
        if(timer <= 0) timer = 0;
        timerText.text = (int)timer + "";
    }
}
