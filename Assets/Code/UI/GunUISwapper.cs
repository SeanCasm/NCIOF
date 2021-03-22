using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUISwapper : MonoBehaviour
{
    [SerializeField]RectTransform gunBullets;
    [SerializeField]int gunBulletSizeWith;
    public static Action<int> gunSwapper;
    private void OnEnable() {
        gunSwapper+=HandleUISwap;
    }
    private void HandleUISwap(int index){
        /*gunBullets.sizeDelta=new Vector2(gunBullets.sizeDelta.x,gunBullets.sizeDelta.y-gunBulletSizeWith);*/
    }
    private void OnDisable() {
        gunSwapper-=HandleUISwap;
    }
}
