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
    // [SerializeField] private Vector2 startPoint = new Vector2(-10, 0);

    // TODO: do a refactor on sounds
    [SerializeField] private AudioClip blastSound = null;
    [SerializeField] private AudioClip destroyCannonSound = null;
    [SerializeField] private AudioClip pauseSound = null;
    [SerializeField] private AudioClip winSound = null;



    private Cannon activeCannon = null;
    private bool isInCannon = false;
    private bool isLose = false;
    private bool isPause = false;
    private bool isWin = false;
    private UIManager uiManager = null;
    private SfxManager sfxManager = null;
    private Collectable[] collectables;

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

    public void Lose()
    {
        StopTime();
        uiManager.ShowMessage("Lose", "Press R to Restart");
        bullet.Dead();
        isLose = true;
    }

    public void Win()
    {
        StopTime();
        uiManager.ShowMessage("You Win!!!", "Press SpaceBar to return to the menu");
        isWin = true;
        sfxManager.PlaySound(winSound);
    }

    private void Awake()
    {
        uiManager = GetComponentInChildren<UIManager>();
        sfxManager = GetComponentInChildren<SfxManager>();
    }

    private void Start()
    {
        cannonManager.SetGameManager(this);
        losingCondition.SetGameManager(this);
        winCondition.SetGameManager(this);
        SetupCollectables();
    }

    private void SetupCollectables()
    {    
        // SetupCollectables 
        collectables = GetComponentsInChildren<Collectable>();
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].GrabItem += GrabItem;
        }
        uiManager.SetupCollectables(collectables);
    }

    private void GrabItem(int collectibleIndex)
    {

    }

    void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isWin)
        {
            Won();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isInCannon && !isPause)
        {
            Fire();
        }
        
        if (Input.GetKeyDown(KeyCode.P) && !isLose && !isWin)
        {
            Pause();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && isLose)
        {
            Retry();
        }
    }

    private void AddedItem(int collectableIndex)
    {

    }

    private void Fire() 
    {
        isInCannon = false;
        activeCannon.Explode();
        sfxManager.PlaySound(destroyCannonSound);

        bullet.Fire(activeCannon.getShotDirection(), activeCannon.getForce());
        sfxManager.PlaySound(blastSound);
        activeCannon = null;
    }

    private void Won()
    {
        ContinueTime();
        SceneManager.LoadScene("MenuStart");
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
            uiManager.ShowMessage("Pause", "Press P to continue");
            sfxManager.PlaySound(pauseSound);
        }
    }

    private void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        isLose = false;
        ContinueTime();
    }

    private void NextLevel()
    {
        string name = SceneManager.GetActiveScene().name;
        string[] aux = name.Split("level");

        int nextLevel = int.Parse(aux[1]) + 1;
        Scene scene = SceneManager.GetSceneByName("level" + nextLevel.ToString());
        SceneManager.LoadScene(scene.name);
    }
}
