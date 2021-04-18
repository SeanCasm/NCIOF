using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Props{
public class SmartyBall : Ball
    {
        [Tooltip("Range time to ball turns to player")]
        [SerializeField] float minTimeTurn, maxTimeTurn;
        new void Awake()
        {
            base.Awake();
        }
        void Start()
        {
            ball = new List<GameObject>();
            Game.Props.Spawn.Ball.totalBallsRemaining++;
            direction = GameObject.FindGameObjectWithTag("Player").transform.position;
            childBall.LoadAssetAsync<GameObject>().Completed += base.OnComplete;
            StartCoroutine(TurnToPlayer());
        }
        new private void FixedUpdate()
        {
            base.FixedUpdate();
        }
        new private void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }
        new private void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);
        }
        IEnumerator TurnToPlayer()
        {
            while (true)
            {
                if (Random.Range(0, 7) == 1)
                {
                    direction = GameObject.FindGameObjectWithTag("Player").transform.position;
                    rigid.SetVelocity(direction * Mathf.Max(lastVelocity.magnitude, 0f));
                }
                yield return new WaitForSeconds(Random.Range(minTimeTurn, maxTimeTurn));
            }
        }
    }
}
 
