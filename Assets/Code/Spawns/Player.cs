using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
namespace Game.Spawn
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Transform playerSpawn;
        private static Transform spawn;
        private void OnEnable()
        {
            DeathScreen.retry += SetSpawn;
        }
        private void OnDisable()
        {
            DeathScreen.retry -= SetSpawn;
        }
        void Start()
        {
            spawn=playerSpawn;
            SetSpawn();
        }
        public static void SetSpawn()
        {
            PlayerController.playerTransform.position = spawn.position;
            PlayerController.playerTransform.gameObject.SetActive(true);
        }
    }
}

