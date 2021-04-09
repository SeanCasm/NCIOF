using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultTierCalculator : MonoBehaviour
{
    [SerializeField]Game.Player.Health playerHealth;
    [SerializeField]float difficultUpdater;
    private void Start() {
        StartCoroutine(UpdateDifficult());
    }
    IEnumerator UpdateDifficult(){
        while(true){
            float precision=Gun.precision;
            var dT=Game.Player.Health.noDamagedTime;
            var dL=BallSpawner.difficultLevel;
            if(precision>=0 && precision<=20){
                dL=1;
            }else if((precision>20 && precision<=50) || dT>=15f){
                dL=2;
            }else if(precision>50 && precision<=80 || dT >= 30f){
                dL=3;
            }
            yield return new WaitForSeconds(difficultUpdater);
        }
    }  
    
}
