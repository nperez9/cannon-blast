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
    private bool isLose = false;
    private bool isWin = false;
    
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
        // uiManager.ShowMessage("Lose", "Press R to Restart");
        bullet.Dead();
        isLose = true;
    }

    public void Win()
    {
        gameState = GameStates.Win;
        StopTime();
        // uiManager.ShowMessage("You Win!!!", "Press SpaceBar to return to the menu");
        isWin = true;
        sfxManager.PlaySound(winSound);
    }

    private void Awake()
    {
        sfxManager = GetComponentInChildren<SfxManager>();
        uiGameplayManager = GetComponentInChildren<UIGamePlayManager>();
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
    }

    private void CheckInputs()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isWin)
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
        if (Input.GetKeyDown(KeyCode.R) && isLose)
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
