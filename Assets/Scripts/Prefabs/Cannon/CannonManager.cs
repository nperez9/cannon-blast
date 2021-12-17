using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prefabs { 
    public class CannonManager : MonoBehaviour
    {
        private GameManager gameManager = null;
        private Cannon[] cannons;

        private void Start()
        {
            cannons = GetComponentsInChildren<Cannon>();
            foreach (Cannon cannon in cannons)
            {
                cannon.SetCannonManager(this);
            }
        }
        public void SetGameManager(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void CannonCollision(Collider2D collision, Cannon cannon)
        {
            gameManager.CannonCollision(collision, cannon);
        }

    }
}