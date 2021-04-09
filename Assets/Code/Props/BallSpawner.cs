using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public sealed class BallSpawner : MonoBehaviour
{
    [Tooltip("Balls prefabs to instantiate, IMPORTANT: the index of the array represents the ball tier.")]
    [SerializeField] AssetReference[] ballsToSpawn;
    [SerializeField] Vector2 spawnerLeftSide,spawnerRightSide;
    [Tooltip("Time to spawn balls throught time")]
    [SerializeField]float minTimeSpawn,maxTimeSpawn;
    List<GameObject> ballTiers=new List<GameObject>();
    public static int difficultLevel=1;
    private const int levelOneParentBallsOnScreen=5,levelTwoParentBallsOnScreen=6,levelThreeParentBallsOnScreen=8;
    public static int totalBallsRemaining;
    private int totalBallTiers,currentBallLoad;
    public static int parentBalls;
    private void Start() {
        totalBallTiers=ballsToSpawn.Length;
        for (int i = 0; i < ballsToSpawn.Length; i++)
        {
            ballsToSpawn[i].LoadAssetAsync<GameObject>().Completed+=OnComplete;
        }
    }
    private void OnComplete(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        ballTiers.Add(obj.Result);
        currentBallLoad++;
        if(totalBallTiers-1==currentBallLoad-1){
            StartCoroutine(Generator());
        }
    }
    #region IEnumerators
    IEnumerator Generator(){
        while(Game.Player.Health.isAlive){
            switch(difficultLevel){
                case 1:
                    parentBalls++;
                    if(parentBalls<=levelOneParentBallsOnScreen){
                        Instantiate(ballTiers[0].gameObject, SpawnerPositionGenerator(), Quaternion.identity, null);
                    }
                break;
                case 2:
                    parentBalls++;
                    if (parentBalls <= levelTwoParentBallsOnScreen)
                    {
                        Instantiate(ballTiers[Random.Range(0, 1)].gameObject, SpawnerPositionGenerator(), Quaternion.identity, null);
                    }
                break;
                case 3:
                    parentBalls++;
                    if (parentBalls <= levelTwoParentBallsOnScreen)
                    {
                        Instantiate(ballTiers[Random.Range(1, 2)].gameObject, SpawnerPositionGenerator(), Quaternion.identity, null);
                    }
                break;
            }
            print(difficultLevel);
            var time=Random.Range(minTimeSpawn, maxTimeSpawn);
            yield return new WaitForSeconds(time);
        }
        ScoreUIHandler.UpdateRM();
    }
    #endregion
    private Vector2 SpawnerPositionGenerator(){
        var xPos= Random.Range(spawnerLeftSide.x,spawnerRightSide.x);
        var yPos=Random.Range(spawnerLeftSide.y,spawnerRightSide.y);
        return new Vector2(xPos,yPos);
    }
}
