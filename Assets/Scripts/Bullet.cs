using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{   
    public BulletStats bulletStats;
    
    public float speed;
    public int damage;

    public Rigidbody2D rb;
    public GameObject impactEffect;
    public GameObject impactWalls;


    void Start ()
    {
        speed = bulletStats.speed;
        damage = bulletStats.damage;
        rb.velocity = transform.right * speed;
        end();
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        VillanoPelon enemy = hitInfo.GetComponent<VillanoPelon>();
        Villano2 enemy2 = hitInfo.GetComponent<Villano2>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
        else
        {
            Instantiate(impactWalls, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
        else
        {
            Instantiate(impactWalls, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    void end()
    {
        StartCoroutine(BulletEnd());
    }

    IEnumerator BulletEnd()
    {
        yield return new WaitForSeconds(.50f);
        Destroy(gameObject);
    }


}
