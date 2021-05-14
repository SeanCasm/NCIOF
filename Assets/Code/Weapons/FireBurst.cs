using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurst : Gun
{
    [Tooltip("Total bullets shoots in burst")]
    [SerializeField]int bulletBurst;
    [SerializeField]float delayPerBurst;
    private int currentBulletsShooted,totalBulletsToShoot;
    private bool burstEnded=true;
    new void OnEnable() {
        if (!base.isSubscribed) DeathScreen.retry += ResetAll;
        base.OnEnable();
    }
    private void OnDisable() {
        burstEnded=true;
        StopAllCoroutines();
        CheckBulletsAfterSwapAmmo();
    }
    new void OnDestroy() {
        DeathScreen.retry-=ResetAll;
    }
    new void Awake() {
        base.Awake();  
    }
    new private void Start() {
        base.Start();
        totalBulletsToShoot=gunProperties.totalAmmo*bulletBurst;
        StartCoroutine(base.WaitBulletLoad(totalBulletsToShoot));
    }
    public override void Shoot()
    {
        if(burstEnded){
            base.Shoot();
            if (currentBulletsShooted == totalBulletsToShoot) currentBulletsShooted = 0;
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay(){
        for (int i = 0; i < bulletBurst; i++)
        {
            var v = bullets[currentBulletsShooted];
            v.transform.SetParent(null);
            v.SetActive(true);
            Bullet bullet = v.GetComponent<Bullet>();
            base.SetDirection(bullet);
            v.transform.eulerAngles = transform.eulerAngles;

            bullet.gun = this;
            currentBulletsShooted++;
            if (i != bulletBurst - 1){
                burstEnded = false;
                yield return new WaitForSeconds(delayPerBurst);
            }else{
                burstEnded = true;
            }
        }
    }
    /// <summary>
    /// Updates the current bullets shooted in this gun. When player swaps the gun at the same time when its shooting, some bullets cannot
    /// be instantiated, so the gun it locks.
    /// </summary>
    private void CheckBulletsAfterSwapAmmo(){
        int rest=currentBulletsShooted%3;
        if(rest!=0 && currentBulletsShooted<totalBulletsToShoot){
            for (int i = currentBulletsShooted; i <= totalBulletsToShoot; i++)
            {
                if(i%3==0)currentBulletsShooted=i;
            }
            if (currentBulletsShooted == totalBulletsToShoot) currentBulletsShooted = 0;
        }
    }
    private void ResetAll(){
        StopAllCoroutines();
        currentBulletsShooted=0;
        burstEnded =true;
    }
}