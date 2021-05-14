using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance; 
    private void Start() {
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(gameObject);
        }else if(instance!=this){
            Destroy(gameObject);
        }
    }
}
