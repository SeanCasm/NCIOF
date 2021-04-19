using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Login
{
    private static string myID;
   
    #region Playfab login
    public static void LogIn(string userName,string password){
        LoginWithPlayFabRequest loginRequest=new LoginWithPlayFabRequest();
        loginRequest.Username=userName;
        loginRequest.Password=password;
        PlayFabClientAPI.LoginWithPlayFab(loginRequest,OnLoginSuccess,OnLoginFailure);
    }
    private static void OnLoginSuccess(LoginResult result){
        SceneManager.LoadScene(1);
        SetClientPersistentData();
    }
    private static async void SetClientPersistentData(){
        PersistentData.SetUserName(myID);
        await Task.Yield();
    }
    private static void OnLoginFailure(PlayFabError error){
        LoginUIHandler.register.Invoke(error.ErrorMessage);
    }
    #endregion
    #region  Playfab register
    public static void Registry(string userName, string password, string email)
    {
        RegisterPlayFabUserRequest registryRequest;
        registryRequest = new RegisterPlayFabUserRequest();
        registryRequest.Email = email;
        registryRequest.Username = userName;
        registryRequest.Password = password;
        PlayFabClientAPI.RegisterPlayFabUser(registryRequest, OnRegisterSuccess,OnRegisterFailure);
    }
    private static void OnRegisterFailure(PlayFabError result){
        LoginUIHandler.register(result.ErrorMessage);
    }
    private static void OnRegisterSuccess(RegisterPlayFabUserResult result){
        myID=result.PlayFabId;
        LoginUIHandler.register("");
    }
    #endregion
}
