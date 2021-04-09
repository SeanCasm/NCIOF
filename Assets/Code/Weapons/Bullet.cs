using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Speed of the bullet, multiplied by Time.deltaTime so needs a high value.")]
    [SerializeField]float speed;

    private Rigidbody2D rigid;
    public float damage { get; set; }
    public Gun gun{get;set;}
    public Vector3 direction{get;set;}
    protected void Awake() {
        rigid=GetComponent<Rigidbody2D>();
    }
    protected void FixedUpdate() {
        rigid.velocity=direction.normalized*speed*Time.deltaTime;
    }
    protected void OnTriggerEnter2D(Collider2D other) {
        switch(other.tag){
            case "Enemy":
                Gun.enemiesImpacted++;
                BackToGun();
            break;
            case "Ground":
                BackToGun();
            break;
        }
    }
    private void OnBecameInvisible() {
        BackToGun();
    }
    /// <summary>
    /// Repositions the bullet back to the weapon that instance it.
    /// </summary>
    private void BackToGun(){
        Gun.Precision();
        gameObject.transform.SetParent(gun.transform);
        gameObject.transform.position=gun.transform.position;
        direction = rigid.velocity=Vector2.zero;

        gameObject.SetActive(false);
    }
    
}
