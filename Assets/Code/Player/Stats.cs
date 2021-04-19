using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
public static class Stats
{
    public static int ballsDestroyed;
    //public static float onMaxLevelTime;
    private static int highScore;
    public static int HighScore{get=>highScore;set{
        if(value>highScore){
            highScore=value;
        }
    }}
}
