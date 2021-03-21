using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class GameSettings : MonoBehaviour
{
    [SerializeField] GameObject redCrossMute;
    [SerializeField]AudioMixer soundsEffects;
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
}