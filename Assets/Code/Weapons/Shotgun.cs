using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]int totalPellets;
    private int pelletsShooted=0;
    new void Start() {
        base.Start();
        for(int i=0;i<totalAmmo*totalPellets;i++){
            //bullets.Add(PhotonNetwork.PrefabPool.Instantiate(bulletName, shootPosition.position, Quaternion.identity));
            bullets[i].transform.SetParent(shootPosition);
        }
    }
    public override void Shoot(){
        base.Shoot();
        for (int i = 50; i >= -50; i -= 25)
        {
            var v = bullets[pelletsShooted];
            v.transform.SetParent(null);
            v.SetActive(true);
            Bullet bullet = v.GetComponent<Bullet>();
            if (transform.root.localScale.x > 0) bullet.direction = transform.right;
            else bullet.direction = -transform.right;
            Quaternion rotation = Quaternion.Euler(0, 0, i);
            bullet.direction=rotation*bullet.direction;
            float zEuler = v.transform.eulerAngles.z;
            zEuler = i;
            v.transform.eulerAngles = new Vector3(0, 0, zEuler);

            bullet.damage = damage;
            pelletsShooted++;
        }
        if(totalAmmo<=0){
            Destroy(gameObject);
        } 
    }
}
