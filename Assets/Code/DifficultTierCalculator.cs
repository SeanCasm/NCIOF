using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierCalculator : MonoBehaviour
{
    [SerializeField]Game.Player.Health playerHealth;
    [SerializeField]float difficultUpdater;
    public static int tierLvl;
    private void Start() {
        StartCoroutine(UpdateDifficult());
    }
    IEnumerator UpdateDifficult(){
        while(true){
            var dT=Game.Player.Health.noDamagedTime;
            var dL=BallSpawner.difficultLevel;
            var score=ScoreHandler.score;
            if(score<=100){
                dL=1;
            }else if((score>100 && score<=200) || dT>=35f){
                dL=2;
            }else if((score>200 && score<=400) || dT >= 60f){
                dL=3;
            }else if((score>400 && score<=750) || dT>=75f){
                dL=4;
            }else if((score>750 && score<1000) && dT>=80f){
                dL=5;
            }
            tierLvl=dL;
            yield return new WaitForSeconds(difficultUpdater);
        }
    }  
    
}
