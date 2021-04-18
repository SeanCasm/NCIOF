using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenObjectMovement : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Vector3 direction;
    protected Rigidbody2D rigid;
    protected Vector2 lastVelocity;
    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    protected void FixedUpdate()
    {
        lastVelocity = rigid.velocity;
        rigid.velocity = direction.normalized * speed;
    }
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            var speed = lastVelocity.magnitude;
            direction = Vector2.Reflect(lastVelocity.normalized, other.contacts[0].normal);
            rigid.SetVelocity(direction * Mathf.Max(speed, 0f));
        }
    }
}
