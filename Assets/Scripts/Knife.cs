using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1000f)]
    public int damage = 100;
    public GameObject impactEffect;
    Transform playerPos;
    GameObject thePlayer;
    Player playerScript;

    void Start()
    {
        thePlayer = GameObject.Find("Player");
        playerScript = thePlayer.GetComponent<Player>();
    }
    void Update() {
        if(playerScript.Flip != true)
        {
            this.transform.localPosition = new Vector2(0.41f,0);
        }
        else
        {
            this.transform.localPosition = new Vector2(-3.380001f,0);
        }
        
    }
    

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        VillanoPelon enemy = hitInfo.GetComponent<VillanoPelon>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            SoundEffects.sfxInstance.Audio.PlayOneShot(SoundEffects.sfxInstance.KnifeAudio);
        } 

        Villano2 enemy2 = hitInfo.GetComponent<Villano2>();
        
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
        } 
    }
}
