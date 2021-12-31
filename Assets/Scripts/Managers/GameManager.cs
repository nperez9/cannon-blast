using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Prefabs;
using Constants;
using Managers;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition = null;
    [SerializeField] private LoseCondition losingCondition = null;
    [SerializeField] private Bullet bullet = null;
    [SerializeField] private CannonManager cannonManager = null;
    [SerializeField] private Vector2 startPoint = new Vector2(-10, 0);
    
    private Cannon activeCannon = null;
    private bool isInCannon = false;
    private bool isLose = false;
    private bool isPause = false;
    private UIManager uiManager = null;

    private void Awake() 
    {
        uiManager = GetComponentInChildren<UIManager>();
    }

    public void CannonCollision(Collider2D collision, Cannon cannon)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER) && activeCannon != cannon)
        {
            BoxCollider2D cannonCollider = cannon.gameObject.GetComponent<BoxCollider2D>();
            cannonCollider.enabled = false;
            activeCannon = cannon;
            isInCannon = true;
            bullet.SetInCannon(cannon.getFirePoint());
        }
    }
    
    private void Start()
    {
        SetupElements();
    }

    private void SetupElements()
    {
        cannonManager.SetGameManager(this);
        losingCondition.SetGameManager(this);
        winCondition.SetGameManager(this);
    }

    void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInCannon && !isPause)
        {
            Fire();
        }
        
        if (Input.GetKeyDown(KeyCode.P) && !isLose)
        {
            Pause();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && isLose)
        {
            Retry();
        }
    }

    private void Fire() 
    {
        isInCannon = false;
        activeCannon.Explode();
        bullet.Fire(activeCannon.getForce());
        activeCannon = null;
    }

    private void ContinueTime()
    {
        Time.timeScale = 1;
    }

    private void StopTime() 
    {
        Time.timeScale = 0;
    }

    private void Pause()
    {
        Debug.Log(Time.timeScale);
        Debug.Log("PAUSA");
        if(Time.timeScale == 0)
        {
            isPause = false;
            uiManager.HideMessage();
            ContinueTime();
        }
        else
        {
            StopTime();
            isPause = true;
            uiManager.ShowMessage("Pause - Press P to continue");
        }
    }

    public void Lose()
    {
        StopTime();
        uiManager.ShowMessage("Lose - Press R to Restart");
        bullet.Dead();
        isLose = true;
    }

    public void Win()
    {
        StopTime();
    }

    private void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        isLose = false;
        ContinueTime();
    }
}
