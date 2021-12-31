using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Image backgroundImage = null;
    private Text text = null;

    void Awake()
    {
        backgroundImage = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        
    }

    public void ShowMessage(string text) {
        ShowMessageElements();
        this.text.text = text;
    }

    private void ShowMessageElements() {
        backgroundImage.enabled = true;
        text.enabled = true;
    }

    public void ShowMessageElements() {
        backgroundImage.enabled = true;
        text.enabled = true;
    }

    public void RemoveMesssage() {
        
    }
}
