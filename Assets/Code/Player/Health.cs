using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Player{
    public class Health : HealthBase<int>
    {
        private SpriteRenderer spriteRenderer;
        private float currentHealth;
        private void Awake() {
            spriteRenderer=GetComponent<SpriteRenderer>();
            currentHealth=health;
        }
        #region Health methods
        public IEnumerator VisualFeedBack(Color color)
        {
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }
         
        public void OnZeroHealth(){
            PlayerController pController=GetComponent<PlayerController>();
            pController.Movement =false;
            pController.IsDeath=true;
        }

        public override void AddDamage(int amount)
        {
            currentHealth -=amount;
            StartCoroutine(VisualFeedBack(Color.red));
            //PlayerUI.updateUI.Invoke(currentHealth);
            if(currentHealth <=0)OnZeroHealth();
        }
        public void AddHealth(int amount){
            if(currentHealth<health){
                float dif=health-currentHealth;
                StartCoroutine(VisualFeedBack(Color.green));
                currentHealth+=amount-dif;
                //PlayerUI.updateUI.Invoke(currentHealth);
            }
        }
        #endregion
    }
}
