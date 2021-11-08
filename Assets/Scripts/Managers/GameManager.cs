using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prefabs;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition = null;
    [SerializeField] private LoseCondition losingCondition = null;
    [SerializeField] private Bullet bullet = null;
    [SerializeField] private CannonManager cannonManager = null;
    [SerializeField] private Vector2 startPoint = new Vector2(-10, 0);
    
    private Cannon activeCannon = null;
    private bool isInCannon = false;
    private bool isLosing = true;

    private void Start()
    {
        SetupElements();
    }

    private void SetupElements()
    {
        losingCondition.SetGameManager(this);
        cannonManager.SetGameManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isInCannon)
        {
            bullet.Fire(activeCannon.getForce());
            isInCannon = false;
            activeCannon = null;
        }
        if (Input.GetKeyDown(KeyCode.P) && !isLosing)
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.R) && isLosing)
        {
            Retry();
        }
    }

    private void Pause()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
            //TODO: SHOW PAUSE
        }
        else
        {
            Time.timeScale = 1;
            //TODO: STOP PAUSE
        }
    }
    public void Lose()
    {
        Pause();
        Debug.Log("You Loose");
        bullet.Dead();
        // TODO: INVOKE UI
    }

    public void Win()
    {
        Pause();
        Debug.Log("You Win");
        // TODO: INVOKE UI
    }

    private void Retry()
    {
        // bullet.Reset()

    }

    public void CannonCollision(Collision2D collision, Cannon cannon)
    {
        if (collision.gameObject.CompareTag("Player") && activeCannon != cannon)
        {
            BoxCollider2D cannonCollider = cannon.gameObject.GetComponent<BoxCollider2D>();
            cannonCollider.enabled = false;
            activeCannon = cannon;
            isInCannon = true;
            bullet.SetInCannon(cannon.getFirePoint());
        }
    }
}
