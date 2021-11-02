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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.Lose();
    }
}
