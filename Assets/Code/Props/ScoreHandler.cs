using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Props.Spawn;
public sealed class ScoreHandler : MonoBehaviour
{
    private static int score;
    public static int tierLvl=1;
    public static int Score
    {
        get => score; 
        set
        {
            score = value;
            if (score <= 100)Ball.tierLvl = 1;
            else if (score > 100 && score <= 200)Ball.tierLvl = 2;
            else if (score > 200 && score <= 400)Ball.tierLvl = 3;
            else if (score > 400 && score <= 750)Ball.tierLvl = 4;
            else if (score > 750 && score < 1000)Ball.tierLvl = 5;
            ScoreUIHandler.score.Invoke(score);
        }
    } 
    private void OnEnable() {
        DeathScreen.deathPause+=ResetScore;
        Pause.leave+=ResetScore;
    }
    private void OnDisable() {
        DeathScreen.deathPause -= ResetScore;
        Pause.leave -= ResetScore;
    }
    private void ResetScore(){
        score=0;
        tierLvl=1;
    }
}
