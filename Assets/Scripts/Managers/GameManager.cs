using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prefabs;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LoseCondition losingCondition = null;
    [SerializeField] private Bullet bullet = null;
    [SerializeField] private CannonManager cannonManager = null;

    private Cannon activeCannon = null;
    private bool isInCannon = false;

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
    }
    public void Lose()
    {
        Debug.Log("You Loose");
    }

    public void CannonCollision(Collision2D collision, Cannon cannon)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activeCannon = cannon;
            Transform firePoint = cannon.GetComponentInChildren<Transform>();
            isInCannon = true;
            BoxCollider2D cannonCollider = cannon.gameObject.GetComponent<BoxCollider2D>();
            cannonCollider.enabled = false;
            bullet.SetInCannon(firePoint.position);
        }
    }
}
