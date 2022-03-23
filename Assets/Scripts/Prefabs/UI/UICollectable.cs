using UnityEngine;
using UnityEngine.UI;

namespace Prefabs.UI
{
    public class UICollectable : MonoBehaviour
    {
        private Image image = null;

        [SerializeField] private Color collectableColor = new Color(255, 255, 255, 255);
        [SerializeField] private Color uncollectedColor = new Color(130, 130, 130, 60);

        private void Start()
        {
            image = GetComponent<Image>();
        }

        public void ActivateCollectable()
        {
            image.enabled = true;
            image.color = uncollectedColor;
        }

        public void Grabbed()
        {
            image.color = collectableColor;
        }
    }
}
