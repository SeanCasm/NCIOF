using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IBullet
{
    [Header("Settings")]
    [Tooltip("Speed of the bullet, multiplied by Time.deltaTime so needs a high value.")]
    [SerializeField]float speed;
    [SerializeField]float lifeTime;
    private Rigidbody2D rigid;
    public Gun gun{get;set;}
    public Vector3 direction{get;set;}
    protected void OnEnable() {
        if (lifeTime != 0)
        {
            Invoke("BackToGun", lifeTime);
        }
        DeathScreen.retry+=BackToGun;
    }
    protected void OnDisable() {
        DeathScreen.retry -= BackToGun;
    }
    protected void Awake() {
        rigid=GetComponent<Rigidbody2D>();
    }
    protected void FixedUpdate() {
        rigid.velocity=direction.normalized*speed*Time.deltaTime;
    }
    protected void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy" || other.tag=="Ground"){
            BackToGun();
        }
    }
    protected void OnBecameInvisible() {
        BackToGun();
    }
    /// <summary>
    /// Repositions the bullet back to the weapon that instance it.
    /// </summary>
    protected void BackToGun(){
        gameObject.transform.SetParent(gun.shootPoint);
        gameObject.transform.position=gun.shootPoint.position;
        direction = rigid.velocity=Vector2.zero;

        gameObject.SetActive(false);
    }
    
}
