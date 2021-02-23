using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villano2 : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect2;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect2, transform.position, Quaternion.identity);
        SoundEffects.sfxInstance.Audio.PlayOneShot(SoundEffects.sfxInstance.DeadEnemyAudio);
        Destroy(gameObject);
    }
}
