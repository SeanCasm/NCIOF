using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurst : Gun
{
    [Tooltip("Total bullets shoots in burst")]
    [SerializeField]int bulletBurst;
    [SerializeField]float delayPerBurst;
    private int bulletsPerBurst;
    private bool burstEnded=true;
    new private void Start() {
        base.Start();
        StartCoroutine(base.WaitBulletLoad(gunProperties.totalAmmo * bulletBurst));
    }
    public override void Shoot()
    {
        base.Shoot();
        if(burstEnded)StartCoroutine(Delay());
        if (bulletsPerBurst == gunProperties.totalAmmo * bulletBurst) bulletsPerBurst = 0;
    }
    IEnumerator Delay(){
        for (int i = 0; i < bulletBurst; i++)
        {
            var v = bullets[bulletsPerBurst];
            v.transform.SetParent(null);
            v.SetActive(true);
            Bullet bullet = v.GetComponent<Bullet>();
            base.SetDirection(bullet);
            v.transform.eulerAngles = transform.eulerAngles;

            bullet.gun = this;
            bulletsPerBurst++;
            if (i == bulletBurst - 1) burstEnded = true;
            else{
                yield return new WaitForSeconds(delayPerBurst);
                burstEnded = false;
            }
        }
    }
}
