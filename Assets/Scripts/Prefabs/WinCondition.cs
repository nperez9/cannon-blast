using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private GameManager gm = null;

    public void SetGameManager(GameManager gm)
    {
        this.gm = gm;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.Win();
    }
}
