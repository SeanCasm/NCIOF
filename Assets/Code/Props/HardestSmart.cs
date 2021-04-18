using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Props
{
    public class HardestSmart : HardSmartBall
    {
        private SpriteRenderer spriteRenderer;
        new void Awake() {
            base.Awake();
            spriteRenderer=GetComponent<SpriteRenderer>();
        }
        new void Start() {
            base.Start();
        }
        new private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Bullet")){
                if(Random.Range(1,3)!=2){
                    base.Break();
                }else{
                    spriteRenderer.color=new Color(255,255,255,0.35f);
                }
            }
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Bullet"))
            {
                spriteRenderer.color = new Color(255, 255, 255, 1);
            }
        }
        new private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        }
    }

}
