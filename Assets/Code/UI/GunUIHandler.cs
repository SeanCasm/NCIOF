using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUIHandler : MonoBehaviour
{
    [SerializeField]RectTransform[] gunBullets;
    [SerializeField]RectTransform[] loadBars;
    public static Action<int,float> gunAmmo;
    private void OnEnable() {
        gunAmmo+=AmmoHandler;
    }
    private void AmmoHandler(int index,float size){
        var sizeDelta=gunBullets[index].sizeDelta;
        float newY=sizeDelta.y+size;
        sizeDelta =new Vector2(sizeDelta.x,newY);
        gunBullets[index].sizeDelta=sizeDelta;
        if(newY==0){
            StartCoroutine(Reload(index));
        }
    }
    IEnumerator Reload(int index){
        while(true){
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnDisable() {
        gunAmmo-=AmmoHandler;
    }
}
