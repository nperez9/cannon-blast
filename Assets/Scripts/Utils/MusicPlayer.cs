using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils { 
    public class MusicPlayer : MonoBehaviour
    {
    
        static MusicPlayer instance = null;
        static string sceneName = "";

        void Awake()
        {
            if (instance != null && sceneName != SceneManager.GetActiveScene().name)
            {
                Destroy(instance.gameObject);
                SetInstance();
            }
            else if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                SetInstance();
            }
        }

        private void SetInstance()
        {
            sceneName = SceneManager.GetActiveScene().name;
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}