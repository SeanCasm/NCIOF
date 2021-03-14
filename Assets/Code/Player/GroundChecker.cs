using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PlayerController pController;
    private const string ground="Ground";
    private void Awake() {
        pController=GetComponentInParent<PlayerController>();    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(ground)){
            pController.IsGrounded=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(ground)){
            pController.IsGrounded=false;
        }
    }
}
