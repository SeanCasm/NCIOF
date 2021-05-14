using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
 
[Serializable]
public class PlayfabUserIsInitialized
{
    public bool IsInitialized;
}
[Serializable]
public class InitialUserData
{
    public int initialCurrency;
}
[Serializable]
public class PlayFabUserPersistentData
{
    public int ballsDestroyed;
    public int highscore;
    public int totalPoints;
    public int highestLevelReached;
    public string username,password;
}
[Serializable]
public class Stats
{
    public int totalPoints;
    public int highscore;

    public int ballsDestroyed;
    public int highestLevelReached;
    public Stats (int points,int ballsDestroyed,int highestLevelReached){
        PersistentData.totalPoints +=points;
        this.totalPoints=PersistentData.totalPoints;

        if (points > PersistentData.highscore){ 
            PersistentData.highscore=this.highscore = points;
        }
        PersistentData.ballsDestroyed=this.ballsDestroyed=ballsDestroyed;
        if(highestLevelReached>PersistentData.highestLevelReached){
            PersistentData.highestLevelReached=this.highestLevelReached=highestLevelReached;
        }
    }
    public Stats(){}
}
public static class UpdatePlayfabUserData
{
    public static void UpdateAll(){
        Stats stats=new Stats(ScoreHandler.Score,Game.Props.Spawn.Ball.ballsDestroyedInGame,ScoreHandler.tierLvl);
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
        {
            Permission = UserDataPermission.Public,
            Data = new Dictionary<string, string>{
                {"stats",JsonUtility.ToJson(stats)}
            }
        }, resultCallback =>
        {

        }, errorCallback =>
        {

        });
    }
}