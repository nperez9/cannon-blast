using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu { 
    public class CursorHandler : MonoBehaviour
    {
        [SerializeField] List<Button> buttons;
        
        public int GetNumberOfButtons()
        {
            return buttons.Count;
        }

        public void UpdateCursor(int index)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i == index)
                {
                    buttons[i].Select();
                }
            }
        }
    }
}