using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CropPlant : MonoBehaviour
{
    [Header("Crop plant settings")]
    [Tooltip("Plant growth time, expressed in seconds.")]
    [SerializeField]int growthTime;
    [SerializeField]Sprite[] plantStages;
    [SerializeField]AssetReference cropReference;
    private List<Transform> cropSpawns=new List<Transform>();
    private GameObject crop;
    private SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer=GetComponent<SpriteRenderer>();
        SetCrops();
        StartCoroutine(PlantGrowth());
        cropReference.LoadAssetAsync<GameObject>().Completed+=OnLoadDone;
    }
    protected void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        crop = obj.Result;
        crop.SetActive(false);
    }
    IEnumerator PlantGrowth(){
        int currentTime=0;
        while(true){
            if(currentTime==growthTime/2){
                spriteRenderer.sprite=plantStages[0];
            }else if(currentTime==growthTime){
                spriteRenderer.sprite = plantStages[1];
                SetCrops();
                break;
            }
            currentTime++;
            yield return new WaitForSeconds(1f);
        }
    }
    private void SetSpawns(){
        foreach(var v in gameObject.GetChilds()){
            cropSpawns.Add(v.transform);
        }
    }
    private void SetCrops(){
        foreach(Transform g in cropSpawns){
            Instantiate(crop,g.position,Quaternion.identity,transform);
        }
    }
}
