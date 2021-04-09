using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField]Text scoreText;
    [SerializeField]Text remainingBalls;
    public static Text rBalls;
    public static Action<int> score,bRemaining;
    private void OnEnable() {
        score+=UpdateScore;
        rBalls=remainingBalls;
    }
    private void OnDisable()
    {
        score -= UpdateScore;
        scoreText.text = "Score: ";
    }
    private void UpdateScore(int amount){
        scoreText.text="Score: "+amount.ToString();
    }
    public static void UpdateRM(){
        rBalls.text = "Balls remaining: " + BallSpawner.totalBallsRemaining.ToString();
    }
}
