using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Managers { 
    public class UIGamePlayManager : MonoBehaviour
    {
        [SerializeField] private GameObject UICollectable;
        [SerializeField] private GameObject UIContainer;

        private Color collectableColor = new Color(183, 177, 85);
        private Color disabledColor = new Color(255, 255, 255, 0.4f);
        private List<GameObject> collectibles;

        public void SetupCollectables(Collectable[] collectables)
        {
            for (int i = 0; i < collectables.Length; i++)
            {
                var uiCollect = Instantiate(UICollectable, UIContainer.transform);
                uiCollect.GetComponent<Image>().color = disabledColor;
                collectibles.Add(uiCollect);
            }
        }

        public void GrabCollectable(int itemIndex)
        {
            collectibles[itemIndex].GetComponent<Image>().color = collectableColor;
        }
    }
}