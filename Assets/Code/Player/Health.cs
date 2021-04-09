using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Player{
    public class Health : HealthBase<int>
    {
        [SerializeField]SpriteRenderer[] bodyRenderers;
        private int currentHealth;
        public static float noDamagedTime;
        public static bool isAlive=true;
        private void Awake() {
            currentHealth=health;
            StartCoroutine(DamageUpdater());
        }
        #region Health methods
        public IEnumerator VisualFeedBack(Color color)
        {
            foreach(var e in bodyRenderers){
                e.color=color;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (var e in bodyRenderers)
            {
                e.color = Color.white;
            }
        }
         
        public void OnDeath(){
            PlayerController pController=GetComponent<PlayerController>();
            isAlive=pController.Movement =false;
            pController.IsDeath=true;
            gameObject.SetActive(false);
        }

        public override void AddDamage(int amount)
        {
            currentHealth -=amount;
            StartCoroutine(VisualFeedBack(Color.red));
            noDamagedTime=0;
            HealthUIHandler.health.Invoke(currentHealth);
            if(currentHealth <=0)OnDeath();
        }
        public void AddHealth(int amount){
            if(currentHealth<health){
                var dif=health-currentHealth;
                StartCoroutine(VisualFeedBack(Color.green));
                currentHealth+=amount-dif;
                HealthUIHandler.health.Invoke(currentHealth);
            }
        }
         
        IEnumerator DamageUpdater(){
            while(true){
                noDamagedTime+=.5f;
                yield return new WaitForSeconds(.5f);
            }
        }
        #endregion
    }
}