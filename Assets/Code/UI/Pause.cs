using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]GameObject pauseScreen,playerHUD,mainMenu;
    private GameObject leaveGame;
    public static Action pause;
    public static Action leave;
    private void OnEnable() {
        pause+=PauseGame;
        DeathScreen.deathPause+=PauseAtDeath;
        leave+=Leave;
        DeathScreen.retry+=UnPauseAtDeath;
    }
    protected void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        leaveGame=obj.Result;
    }
    private void OnDisable() {
        pause-=PauseGame;
        DeathScreen.deathPause-=PauseAtDeath;
        DeathScreen.retry -= UnPauseAtDeath;
        leave-=Leave;
    }
    private void PauseAtDeath(){
        Time.timeScale = 0;
    }
    private void PauseGame(){
        if(Time.timeScale==1){
            pauseScreen.SetActive(true);
            Time.timeScale=0;
        } else {
            Unpause();
        }
    }
    private void UnPauseAtDeath(){
        Time.timeScale=1;
    }
    private void Unpause(){
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void UnpauseGameButton(){
        Unpause();
    }
    public void LeaveToMainMenu(){
        leave.Invoke();
    }
    private void Leave(){
        Unpause();
        playerHUD.SetActive(false);
        SceneManager.LoadScene(0);
        mainMenu.SetActive(true);
    }
    public void Back(){

    }
}
