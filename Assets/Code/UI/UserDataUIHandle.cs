using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataUIHandle : MonoBehaviour
{
    [SerializeField]Image playerIcon;
    [SerializeField]TMPro.TextMeshProUGUI[] userName;
    [SerializeField]Text accountCreated,highScore,ballsDestroyed,timePlayed,totalPoints,highestLevel;
    private void OnEnable() {
        SetDataUI();
    } 
    private void SetDataUI(){
        foreach(var e in userName){
            e.text=PersistentData.userName;
        }
        //accountCreated.text="Created: "+creationDate;
        highScore.text="High score: "+PersistentData.highscore.ToString();
        ballsDestroyed.text="Balls destroyed: "+PersistentData.ballsDestroyed.ToString();
       /* timePlayed.text="Time played: "+initialUserData.timePlayed.ToString();*/
        totalPoints.text="Total points: "+PersistentData.totalPoints.ToString();
        highestLevel.text="Highest level reached: "+PersistentData.highestLevelReached.ToString();
    }
}
