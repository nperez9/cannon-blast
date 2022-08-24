using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    
    static MusicPlayer instance = null;
    static string sceneName = "";

    void Awake()
    {
        if (instance != null && sceneName == SceneManager.GetActiveScene().name)
        {
            Destroy(gameObject);
        }
        else
        {
            sceneName = SceneManager.GetActiveScene().name;
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}