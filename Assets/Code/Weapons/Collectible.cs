using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectible : MonoBehaviour
{
    [SerializeField]CollectibleType collectType=CollectibleType.none;
    [SerializeField]protected float amount;
    public CollectibleType CollectType {get=>collectType;set=>collectType=value;}
}
