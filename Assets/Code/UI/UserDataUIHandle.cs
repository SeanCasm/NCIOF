using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDataUIHandle : MonoBehaviour
{
    public static UserDataUIHandle instance;
    [SerializeField]Image playerIcon;
    [SerializeField]TMPro.TextMeshProUGUI userName;
    [SerializeField]Text accountCreated;
    public Action<SetUserDataUI> dataUI;
    private void Start() {
        if(instance==null){
            instance = this;
        }
    }
    private void OnEnable() {
        dataUI+=SetDataUI;
    }
    private void OnDisable() {
        dataUI-=SetDataUI;
    }
    private void SetDataUI(SetUserDataUI userData){
        userName.text=userData.userName;
        playerIcon.sprite=userData.playerIcon;
        accountCreated.text=userData.accountCreated;
    }
    
    public class SetUserDataUI:EventArgs{
        public Sprite playerIcon;
        public string userName;
        public string accountCreated;
    }
}
