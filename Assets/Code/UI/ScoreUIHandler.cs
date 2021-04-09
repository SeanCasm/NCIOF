using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField]Text scoreText;
    public static Text rBalls;
    public static Action<int> score;
    private void OnEnable() {
        score+=UpdateScore;
    }
    private void OnDisable()
    {
        score -= UpdateScore;
        scoreText.text = "Score: ";
    }
    private void UpdateScore(int amount){
        scoreText.text="Score: "+amount.ToString();
    }
}
