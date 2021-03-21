using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
public class GameSettings : MonoBehaviour
{
    [SerializeField] GameObject redCrossMute;
    [SerializeField] AudioMixer soundsEffects;
    public void MuteAll(){
        bool muted = AudioListener.pause = !AudioListener.pause;
        if (muted) redCrossMute.SetActive(true);
        else redCrossMute.SetActive(false);
    }
    public void AddSoundEffectsLevel(float amount){

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadScene(int index){
        SceneManager.LoadSceneAsync(index);
    }
}