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
    private static string userName,password;
    #region Playfab login
    public static void LogIn(string username,string password){
        LoginWithPlayFabRequest loginRequest=new LoginWithPlayFabRequest();
        userName=loginRequest.Username=username;
        password=loginRequest.Password=password;
        PlayFabClientAPI.LoginWithPlayFab(loginRequest,OnLoginSuccess,OnLoginFailure);
    }
    private static void OnLoginSuccess(LoginResult result){
        PersistentData.SetUserName(userName);
        LoginUIHandler.login("");
    }
    private static void OnLoginFailure(PlayFabError error){
        LoginUIHandler.login(error.ErrorMessage);
    }
    #endregion
    #region  Playfab register
    public static void Registry(string username, string password, string email)
    {
        RegisterPlayFabUserRequest registryRequest;
        registryRequest = new RegisterPlayFabUserRequest();
        registryRequest.Email = email;
        registryRequest.Username = username;
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
