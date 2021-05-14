using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bazooka : Gun
{
    new void OnEnable() {
        base.OnEnable();
    }
    new void Awake() {
        base.Awake();
    }
    new void Start()
    {
        base.Start();
        StartCoroutine(base.WaitBulletLoad());
    }

    new void OnDestroy() {
        base.OnDestroy();
    }
    public override void Shoot()
    {
        base.Shoot();
        var obj = bullets[currentAmmo];
        Bullet gunBullet = obj.GetComponent<Bullet>();
        obj.SetActive(true);
        obj.transform.SetParent(null);
        base.SetDirection(gunBullet);
        obj.transform.eulerAngles = transform.eulerAngles;
        gunBullet.gun = this;
    }
}
