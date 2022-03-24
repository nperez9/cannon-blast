using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using Menu;

namespace Managers { 
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] string pauseTitle = "PAUSE";
        [SerializeField] string pauseSubtitle = "";
        [SerializeField] string loseTitle = "YOU LOSE";
        [SerializeField] string loseSubtitle = "Choose an option";
        [SerializeField] string wonTitle = "YOU WON!!!!";
        [SerializeField] string wonSubtitle = "";

        [SerializeField] private GameObject pauseMenu = null;
        [SerializeField] private GameObject loseMenu = null;
        [SerializeField] private GameObject winMenu = null;

        [SerializeField] TextMeshProUGUI title = null;
        [SerializeField] TextMeshProUGUI description = null;

        private int cursor;
        private CursorHandler ActualCursor = null;

        public void HandleUpdate()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                cursor++;
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                cursor--;

            cursor = Math.Clamp(cursor, 0, ActualCursor.GetNumberOfButtons() - 1);
            ActualCursor.UpdateCursor(cursor);
        }

        public void WonMenu()
        {
            cursor = 0;
            ActualCursor = winMenu.GetComponent<CursorHandler>();

            title.text = wonTitle;
            description.text = wonSubtitle;

            this.gameObject.SetActive(true);
            pauseMenu.SetActive(false);
            loseMenu.SetActive(false);
            winMenu.SetActive(true);
        }

        public void PauseMenu()
        {
            cursor = 0;
            ActualCursor = pauseMenu.GetComponent<CursorHandler>();
        
            title.text = pauseTitle;
            description.text = pauseSubtitle;

            this.gameObject.SetActive(true);
            pauseMenu.SetActive(true);
            loseMenu.SetActive(false);
            winMenu.SetActive(false);
        }

        public void LoseMenu()
        {
            cursor = 0;
            ActualCursor = loseMenu.GetComponent<CursorHandler>();

            title.text = loseTitle;
            description.text = loseSubtitle;

            this.gameObject.SetActive(true);
            pauseMenu.SetActive(false);
            loseMenu.SetActive(true);
            winMenu.SetActive(false);
        }

        public void BackToMenu()
        {
            Scene scene = SceneManager.GetSceneByName("MenuStart");
            SceneManager.LoadScene(scene.name);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
            cursor = 0;
            ActualCursor = null;
        }
    }
}