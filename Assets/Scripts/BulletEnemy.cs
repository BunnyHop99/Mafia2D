using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField, Range(0.1f, 100f)]
    public float speed = 0f;
    public int damage = 50;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    
    void Start ()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Player enemy = hitInfo.GetComponent<Player>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
                
            Destroy(gameObject);
        } 
    }
}
