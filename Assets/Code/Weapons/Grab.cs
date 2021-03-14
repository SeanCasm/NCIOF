using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Grab : MonoBehaviour
{
    [SerializeField] Transform frontArm;
    [SerializeField] Transform gunPoint; 
    [SerializeField] Animator backArmAnimator;
    [SerializeField] Transform backArmTarget;
    [Tooltip("Back arm LimbSolver2D to update the arm target following player aim with two hands gun.")]
    [SerializeField] LimbSolver2D limbSolver2D;
    Collider2D hurt;
    private PlayerController playerController;
    public static Action throwGun;
    private void Awake() {
        throwGun +=HandleThrow;
        playerController=GetComponentInParent<PlayerController>();
        hurt=GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Gun")){
            Transform otherTransform=other.transform;
            Vector2 scale=otherTransform.localScale;
            otherTransform.SetParent(frontArm);
            otherTransform.position=gunPoint.position;
            otherTransform.localScale=gunPoint.localScale; // the scale sets back to x:1,y:1
            
            otherTransform.rotation=gunPoint.transform.parent.rotation;
            Gun gun=other.GetComponent<Gun>();
            playerController.gun=gun;
            if(gun.GunGrabType==Gun.HandsForGrab.two){
                limbSolver2D.gameObject.SetActive(true);
                Transform grabPoint=other.gameObject.GetChild(1).transform;
                playerController.twoHandsGun=grabPoint;
                backArmTarget.SetParent(grabPoint);
                backArmTarget.localPosition=Vector2.zero;
                backArmAnimator.enabled=false;
            }
        }
    }
    private void HandleThrow(){
        limbSolver2D.gameObject.SetActive(false);
        backArmAnimator.enabled=true;
    }
    private void OnDisable() {
        throwGun-=HandleThrow;
    }
}
