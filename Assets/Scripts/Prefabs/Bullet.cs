using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float baseForce = 100.0f;

    private Rigidbody2D rb = null;
    private BoxCollider2D boxCollider = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Fire(float force = 1.0f)
    {
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        boxCollider.enabled = true;
        rb.AddForce(Vector2.up * force * baseForce, ForceMode2D.Impulse);
    }

    public void SetInCannon(Transform firePoint) 
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = firePoint.position;
        transform.SetParent(firePoint);
    }
}
