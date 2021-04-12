using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ScoreHandler : MonoBehaviour
{
    [SerializeField]Game.Player.Health pHealth;
    private static int score;
    public static int tierLvl=1;
    public static int Score
    {
        get => score; 
        set
        {
            score = value;
            var dT = Game.Player.Health.noDamagedTime;
            if (score <= 100)
            {
                BallSpawner.tierLvl = 1;
            }
            else if ((score > 100 && score <= 200) || dT >= 40f)
            {
                BallSpawner.tierLvl = 2;
            }
            else if ((score > 200 && score <= 400) || dT >= 60f)
            {
                BallSpawner.tierLvl = 3;
            }
            else if ((score > 400 && score <= 750) || dT >= 80f)
            {
                BallSpawner.tierLvl = 4;
            }
            else if ((score > 750 && score < 1000) && dT >= 120f)
            {
                BallSpawner.tierLvl = 5;
            }
        }
    }
}
