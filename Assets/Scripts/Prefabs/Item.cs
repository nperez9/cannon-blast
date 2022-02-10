using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Constants;

public class Item : MonoBehaviour
{
    [SerializeField] private int itemIndex = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(Tags.PLAYER))
        {
            Debug.Log("test");
        }
    }
}
