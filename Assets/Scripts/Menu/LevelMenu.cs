using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu { 
    public class LevelMenu : MonoBehaviour
    {
        public void LoadLevel(string lvlNumber)
        {
            SceneManager.LoadScene("level" + lvlNumber);
        }
    }
}
