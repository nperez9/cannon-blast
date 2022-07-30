using System.Collections.Generic;

using UnityEngine;
using Prefabs.UI;

namespace Managers { 
    public class UIGamePlayManager : MonoBehaviour
    {
        [SerializeField] private List<UICollectable> collectibles;

        public void SetupCollectables(Collectable[] collectables)
        {
            try { 
                for (int i = 0; i < collectables.Length; i++)
                {
                    collectibles[i].ActivateCollectable();
                }
            } 
            catch
            {
                Debug.Log(collectables);
                Debug.Log(collectibles);
            }
        }

        public void GrabCollectable(int itemIndex)
        {
            collectibles[itemIndex].Grabbed();
        }
    }
}