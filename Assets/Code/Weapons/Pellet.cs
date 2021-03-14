using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : Bullet
{
    [SerializeField]float totalAngles;
    new void Awake()
    {
        base.Awake();
    }
    new void FixedUpdate()
    {
        base.FixedUpdate();
    }
    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
     
}
