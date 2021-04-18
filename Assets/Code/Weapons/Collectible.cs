using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectible : ScreenObjectMovement
{
    [SerializeField]protected float lifeTime;
    protected void Start() {
        direction = Random.insideUnitCircle.normalized;
        Destroy(gameObject,lifeTime);
    }
}
