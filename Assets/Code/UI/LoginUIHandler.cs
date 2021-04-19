using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LoginUIHandler : MonoBehaviour
{
    [SerializeField] Text registerMessage;
    [SerializeField]UnityEvent registerSuccess;
    public bool onRegistry{get;set;}
    public string userName{get;set;}
    public string email{get;set;}
    public string password{get;set;}
    private Color registerDefault;
    public static Action<string> register;
    private void OnEnable() {
        register+=RegisterEvent;
        registerDefault=registerMessage.color;
        registerSuccess.AddListener(()=>{
            registerMessage.text="Account succesfully created!";
            registerMessage.color=Color.green;
            Invoke("ClearMessage",3f);
        });
    }
    private void OnDisable() {
        register-=RegisterEvent;
    }
    public void CheckCredentials(){
        if(onRegistry)Login.Registry(userName,password,email);
        else Login.LogIn(userName,password);
    }
    private void RegisterEvent(string errorDetails){
        if(!string.IsNullOrEmpty(errorDetails)){
            registerDefault = registerMessage.color;
            registerMessage.text = errorDetails;
            registerMessage.color = Color.red;
            Invoke("ClearMessage", 3f);
        }else{
            registerSuccess.Invoke();
        } 
    }
    private void ClearMessage(){
        registerMessage.text="";
        registerMessage.color=registerDefault;
    }
}
