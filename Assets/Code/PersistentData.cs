using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public static void SetUserName(string username)
    {
        userName=username;
        UserDataUIHandle.dataUI(username);
    }
}
