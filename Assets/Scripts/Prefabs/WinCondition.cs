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

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gm.Win();
    }
}
