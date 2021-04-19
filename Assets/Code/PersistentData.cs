using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData
{
    private static string userName;
    private static int highScore;
    public static int ballsDestroyed;
    public static int HighScore
    {
        get => highScore; 
        set
        {
            if (value > highScore)
            {
                highScore = value;
            }
        }
    }
    public static void SetUserName(string userName){
        PersistentData.userName =userName;
        UserDataUIHandle.instance.dataUI(new UserDataUIHandle.SetUserDataUI
        {
            userName=userName,
            playerIcon=null
        });
    }
}
