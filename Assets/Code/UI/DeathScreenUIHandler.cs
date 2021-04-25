using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathScreenUIHandler : MonoBehaviour
{
    public void Retry(){
        DeathScreen.retry.Invoke();
    }
}
