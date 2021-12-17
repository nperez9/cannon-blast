using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gameManager.Lose();
    }
}
