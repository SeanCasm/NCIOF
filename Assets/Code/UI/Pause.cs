using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]GameObject canvas;
    public static Pause instance;
    private void Start() {
        instance=this;
    }
    public void PauseGame(){
        if(Time.timeScale==1){
            canvas.SetActive(true);
            Time.timeScale=0;
        
        }
        else {
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
}
