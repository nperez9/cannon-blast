using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float baseForce = 100.0f;
    [SerializeField] Sprite deadSprite = null;
    [SerializeField] GameObject spriteReference = null;

    private Rigidbody2D rb = null;
    private CircleCollider2D circleCollider = null;
    private SpriteRenderer spriteR = null;
    private Transform spriteTransform = null;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteR = spriteReference.GetComponent<SpriteRenderer>();
        spriteTransform = spriteReference.GetComponent<Transform>();
    }

    public void Fire(Vector2 direction, float force = 1.0f)
    {
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        circleCollider.enabled = true;
        rb.AddForce(direction * force * baseForce, ForceMode2D.Impulse);
    }

    public void SetInCannon(Transform firePoint) 
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = firePoint.position;
        spriteTransform.rotation = firePoint.rotation;
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
