using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Constants;

public class LoseCondition : MonoBehaviour
{
    private GameManager gameManager = null;


    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            gameManager.Lose();
        }            
    }
}
