using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float baseForce = 100.0f;
    [SerializeField] Sprite deadSprite = null; 

    private Rigidbody2D rb = null;
    private BoxCollider2D boxCollider = null;
    private SpriteRenderer spriteR = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteR = GetComponent<SpriteRenderer>();
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

    public void Dead()
    {
        spriteR.sprite = deadSprite;
    }

    public void Reset()
    {
        
    }
}
