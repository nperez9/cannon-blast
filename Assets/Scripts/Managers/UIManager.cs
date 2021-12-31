using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private Image backgroundImage = null;
        private Text text = null;

        void Awake()
        {
            backgroundImage = GetComponentInChildren<Image>();
            text = GetComponentInChildren<Text>();
        }

        public void ShowMessage(string text) {
            ShowMessageElements();
            this.text.text = text;
        }

        public void HideMessage() 
        {
            this.text.text = "";
            HideMessageElements();
        }

        private void ShowMessageElements() {
            backgroundImage.enabled = true;
            text.enabled = true;
        }

        private void HideMessageElements() {
            backgroundImage.enabled = false;
            text.enabled = false;
        }
    }
}