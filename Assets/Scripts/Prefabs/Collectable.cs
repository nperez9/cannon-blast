using System;
using UnityEngine;

using Constants;

public class Collectable : MonoBehaviour
{
    public event Action<int> GrabItem;

    [SerializeField] private int itemIndex = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(Tags.PLAYER))
        {
            Debug.Log("test");
        }
    }
}
