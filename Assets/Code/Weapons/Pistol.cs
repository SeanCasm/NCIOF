using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    new void Start(){
        base.Start();
        for (int i = 0; i < totalAmmo; i++)
        {
            //bullets.Add(PhotonNetwork.PrefabPool.Instantiate(bulletName, shootPosition.position, Quaternion.identity));
            bullets[i].transform.SetParent(shootPosition);
        }
    }
    public override void Shoot()
    {
        base.Shoot();
        var obj = bullets[totalAmmo];
        Bullet gunBullet = obj.GetComponent<Bullet>();
        obj.SetActive(true);
        obj.transform.SetParent(null);
        if (transform.root.localScale.x > 0) gunBullet.direction = transform.right;
        else gunBullet.direction = -transform.right;
        gunBullet.damage = damage;
        //gunBullet =null;
        if (totalAmmo <= 0)
        {
            Grab.throwGun.Invoke();
            Destroy(gameObject);
        }
    }
}
