using UnityEngine;
using UnityEngine.SceneManagement;

using Prefabs;
using Constants;
using Managers;

public enum GameStates { GamePlay, Menu, Win, Lose, Pause };

public class GameManager : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition = null;
    [SerializeField] private LoseCondition losingCondition = null;
    [SerializeField] private Bullet bullet = null;
    [SerializeField] private CannonManager cannonManager = null;
    [SerializeField] private MenuManager menuManager = null;

    // TODO: do a refactor on sounds
    [SerializeField] private AudioClip blastSound = null;
    [SerializeField] private AudioClip destroyCannonSound = null;
    [SerializeField] private AudioClip pauseSound = null;
    [SerializeField] private AudioClip winSound = null;

    private GameStates gameState = GameStates.GamePlay;
    private Cannon activeCannon = null;
    private bool isInCannon = false;
    
    private SfxManager sfxManager = null;
    private UIGamePlayManager uiGameplayManager = null;
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
        gameState = GameStates.Lose;
        StopTime();
        bullet.Dead();
        menuManager.LoseMenu();
    }

    public void Win()
    {
        gameState = GameStates.Win;
        StopTime();
        sfxManager.PlaySound(winSound);
        menuManager.WonMenu();
    }

    private void Awake()
    {
        sfxManager = GetComponentInParent<SfxManager>();
        uiGameplayManager = GetComponentInChildren<UIGamePlayManager>();
    }

    private void Start()
    {
        cannonManager.SetGameManager(this);
        losingCondition.SetGameManager(this);
        winCondition.SetGameManager(this);
        SetupCollectables();
        // for if you lose/win and go back to menu
        ContinueTime();
    }

    private void SetupCollectables()
    {    
        collectables = GetComponentsInChildren<Collectable>();
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].GrabItem += GrabItem;
            collectables[i].gameObject.SetActive(true);
        }
        uiGameplayManager.SetupCollectables(collectables);
    }

    private void GrabItem(int collectibleIndex)
    {
        collectables[collectibleIndex].gameObject.SetActive(false);
        uiGameplayManager.GrabCollectable(collectibleIndex);
    }

    void Update()
    {
        CheckInputs();
        if (gameState == GameStates.Lose || gameState == GameStates.Pause || gameState == GameStates.Win)
        {
            menuManager.HandleUpdate();
        }
    }

    private void CheckInputs()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameState == GameStates.Win)
        {
            Won();
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameState == GameStates.GamePlay && isInCannon)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.P) && (gameState == GameStates.GamePlay || gameState == GameStates.Pause))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.R) && gameState == GameStates.Lose)
        {
            Retry();
        }
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

    public void Pause()
    {
        if(gameState == GameStates.GamePlay)
        {
            StopTime();
            gameState = GameStates.Pause;
            menuManager.PauseMenu();
            sfxManager.PlaySound(pauseSound);
        }
        else
        {
            gameState = GameStates.GamePlay;
            menuManager.Hide();
            ContinueTime();
        }
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gameState = GameStates.GamePlay;
        menuManager.Hide();
        ContinueTime();
    }

    public void NextLevel()
    {
        string name = SceneManager.GetActiveScene().name;
        string[] aux = name.Split("level");

        int nextLevel = int.Parse(aux[1]) + 1;
        SceneManager.LoadScene(nextLevel);
    }
}
