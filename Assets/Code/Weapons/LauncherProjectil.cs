using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LauncherProjectil : Bullet
{
    [SerializeField] AssetReference impactPrefab,explosionPrefab;
    [SerializeField]float impactPreabLifeTime,explosionPrefabLifeTime;
    private GameObject impactPr,explosionPr;
    #region Unity methods
    new void OnEnable()
    {
        base.OnEnable();
    }
    new void OnDisable()
    {
        base.OnDisable();
    }
    new void Awake()
    {
        base.Awake();
        impactPrefab.LoadAssetAsync<GameObject>().Completed+=OnLoadDone;
        explosionPrefab.LoadAssetAsync<GameObject>().Completed+=OnLoadDone2;
    }
    new void FixedUpdate()
    {
        base.FixedUpdate();
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Enemy")){
            GameObject impact = Instantiate(impactPr, transform.position, Quaternion.identity);
            impact.SetActive(true);
            GameObject explosion = Instantiate(explosionPr, transform.position, Quaternion.identity);
            explosion.SetActive(true);
            base.BackToGun();
            Destroy(explosion,explosionPrefabLifeTime);
            Destroy(impact,impactPreabLifeTime);
        }
    }
    new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }
    #endregion
    protected void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        impactPr = obj.Result;
        impactPr.SetActive(false);
    }
    protected void OnLoadDone2(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        explosionPr = obj.Result;
        explosionPr.SetActive(false);
    }
}
