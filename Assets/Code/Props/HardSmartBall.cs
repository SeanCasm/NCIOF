using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Props{
public class HardSmartBall : Ball
    {
        protected Transform player;
        new void Awake()
        {
            base.Awake();
        }
        protected void Start()
        {
            ball = new List<GameObject>();
            Game.Props.Spawn.Ball.totalBallsRemaining++;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            direction = player.position;
            childBall.LoadAssetAsync<GameObject>().Completed += base.OnComplete;
        }
        new private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        }
        new private void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }
        new private void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);
        }
    }
}
 