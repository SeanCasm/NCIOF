using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]GameObject canvas;
    private GameObject leaveGame;
    private GameObject leaveGameIns;
    public static Action pause;
    public static event Action<bool> Paused;
    public static bool paused;
    private void OnEnable() {
        pause+=PauseGame;
    }
    protected void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        leaveGame=obj.Result;
    }
    private void OnDisable() {
        pause-=PauseGame;
    }
    private void PauseGame(){
        if(Time.timeScale==1){
            canvas.SetActive(true);
            Paused.Invoke(false);
            Time.timeScale=0;
        } else {
            Paused.Invoke(true);
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void UnpauseGameButton(){
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Leave(bool leave){
        leaveGameIns.SetActive(true);
        if(leave){
            SceneManager.LoadScene(0);
        }else{
            leaveGameIns.SetActive(false);
        }
         
    }
}
