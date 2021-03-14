using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]protected int totalAmmo;
    [SerializeField]protected float damage;
    [SerializeField]protected string bulletName;
    [Tooltip("The grab type from the gun, one hand for small guns, and two hands for big guns.")]
    [SerializeField]HandsForGrab grabType; 
    public HandsForGrab GunGrabType{get=>grabType;}
    public enum HandsForGrab
    {
        one, two
    }

    protected List<GameObject> bullets;
    protected Transform shootPosition;
    protected void Start() {
        shootPosition=gameObject.GetChild(0).transform;
        bullets=new List<GameObject>();
    }
    public virtual void Shoot(){
        totalAmmo--;
    }
}
