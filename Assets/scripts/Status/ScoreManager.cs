using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int Score;

    private void Update() 
    {
        scoreText.text = "Score : " + Score;    
    }

    public void AddScore(in int addscore)
    {
        Score = Score + addscore; 
    }
}
