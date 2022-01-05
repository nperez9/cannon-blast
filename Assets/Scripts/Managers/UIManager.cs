using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private Image backgroundImage = null;
        private TextMeshProUGUI title = null;
        private TextMeshProUGUI description = null;

        private void Awake()
        {
            backgroundImage = GetComponentInChildren<Image>();
            title = GetComponentsInChildren<TextMeshProUGUI>()[0];
            description = GetComponentsInChildren<TextMeshProUGUI>()[1];
        }

        private void Start()
        {
            HideMessage();
        }

        public void ShowMessage(string title, string description = "") {
            ShowMessageElements();
            this.title.text = title;
            this.description.text = description;
        }

        public void HideMessage() 
        {
            title.text = "";
            description.text = "";
            HideMessageElements();
        }

        private void ShowMessageElements() {
            backgroundImage.enabled = true;
            title.enabled = true;
            description.enabled = true;
        }

        private void HideMessageElements() {
            backgroundImage.enabled = false;
            title.enabled = false;
            description.enabled = false;
        }
    }
}