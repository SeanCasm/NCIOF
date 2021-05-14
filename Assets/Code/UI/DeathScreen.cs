using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class DeathScreen : MonoBehaviour
{
    [SerializeField]Canvas canvas;
    [SerializeField]AssetReference deathScreenRef;
    private GameObject deathScreen,deathScreenPrefab;
    public static System.Action deathPause,retry;
    public static System.Action destroyScreen;

    private void OnEnable() {
        Game.Player.Health.onDeath+=ShowScreen;
        retry +=Retry;
        destroyScreen+=SelfDestroy;
    }
    private void OnDisable() {
        Game.Player.Health.onDeath -= ShowScreen;
        retry -=Retry;
        destroyScreen -= SelfDestroy;
    }
    private void Start() {
        deathScreenRef.LoadAssetAsync<GameObject>().Completed+=OnLoadDone;
    }
    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj){
        deathScreen =obj.Result;
    }
    private void ShowScreen(){
        if(deathScreenPrefab==null)deathScreenPrefab=Instantiate(deathScreen,canvas.transform.position,Quaternion.identity,canvas.transform);
    }
    private void SelfDestroy(){
        Destroy(deathScreenPrefab);
    }
    private void Retry(){
        SelfDestroy();
    }
}
