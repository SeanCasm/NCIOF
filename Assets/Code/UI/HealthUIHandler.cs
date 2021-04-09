using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HealthUIHandler : MonoBehaviour
{
    [SerializeField]RectTransform heartRect;
    [SerializeField]int heartWidthSize;
    [SerializeField]Animator heartAnimator;
    public static Action<int> health;
    private void OnEnable() {
        health+=UpdateHealth;
    }
    private void OnDisable() {
        health-=UpdateHealth;
    }
    /// <summary>
    /// Updates the player health UI.
    /// </summary>
    /// <param name="amount">current amount of health on player</param>
    private void UpdateHealth(int amount){
        heartRect.sizeDelta=new Vector2(heartWidthSize*amount,heartRect.sizeDelta.y);
        heartAnimator.SetTrigger("Scale");
    }
}
