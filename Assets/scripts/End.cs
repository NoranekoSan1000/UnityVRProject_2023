using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Scoretext;
    int FinalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        FinalScore = HPManager.HP * 200 + ScoreManager.Score;
        Scoretext.text = "Score : " + FinalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
