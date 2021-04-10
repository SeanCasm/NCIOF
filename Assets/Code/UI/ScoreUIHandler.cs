using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField]Text scoreText;
    [SerializeField]TextMeshProUGUI text;
    public static Action<int,int> score;
    private void OnEnable() {
        score+=UpdateScore;
    }
    private void OnDisable()
    {
        score -= UpdateScore;
        scoreText.text = "Score: ";
    }
    private void UpdateScore(int amount,int level){
        scoreText.text="Score: "+amount.ToString();
        text.text="Level: "+level.ToString();
    }
}
