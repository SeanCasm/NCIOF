using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurst : Gun
{
    [Tooltip("Total bullets shoots in burst")]
    [SerializeField]int bulletBurst;
    [SerializeField]float delayPerBurst;
    private int totalBulletsShooted;
    private bool burstEnded=true;
    new private void Start() {
        base.Start();
        StartCoroutine(base.WaitBulletLoad(gunProperties.totalAmmo * bulletBurst));
    }
    public override void Shoot()
    {
        if(burstEnded){
            base.Shoot();
            if (totalBulletsShooted == gunProperties.totalAmmo * bulletBurst) totalBulletsShooted = 0;
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay(){
        for (int i = 0; i < bulletBurst; i++)
        {
            var v = bullets[totalBulletsShooted];
            v.transform.SetParent(null);
            v.SetActive(true);
            Bullet bullet = v.GetComponent<Bullet>();
            base.SetDirection(bullet);
            v.transform.eulerAngles = transform.eulerAngles;

            bullet.gun = this;
            totalBulletsShooted++;
            if (i != bulletBurst - 1){
                burstEnded = false;
                yield return new WaitForSeconds(delayPerBurst);
            }else{
                burstEnded = true;
            }
        }
    }
}
