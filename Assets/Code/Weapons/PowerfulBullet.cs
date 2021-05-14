using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerfulBullet : Bullet
{

    new void OnEnable() {
        base.OnEnable();
    }
    new void OnDisable() {
        base.OnDisable();
    }
    new void Awake() {
        base.Awake();
    }
    new void FixedUpdate() {
       base.FixedUpdate(); 
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))base.BackToGun();
    }
    new void OnBecameInvisible() {
        base.OnBecameInvisible();
    }
}
