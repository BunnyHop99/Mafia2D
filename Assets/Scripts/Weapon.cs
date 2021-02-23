using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    Animator anim;
    PlayerControls playerControls;
    GameObject knifePoint;
    private float tiempo;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerControls = new PlayerControls ();
        knifePoint = GameObject.Find("KnifePoint");

        knifePoint.SetActive(false);
    }

    void Start()
    {
        playerControls.Gameplay.Fire1.performed += ctx => Fire1();
        playerControls.Gameplay.Fire2.performed += ctx => Fire2();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Update() 
    {
        tiempo += Time.deltaTime;
    }

    void Fire1()
    {
        if(tiempo >= .40)
        {
            anim.SetTrigger("shoot");
            Shoot();
            tiempo = 0;
        }   
    }

    void Shoot()
    {
        StartCoroutine(WeaponCoroutine());
    }

    IEnumerator WeaponCoroutine()
    {
        yield return new WaitForSeconds(.10f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        SoundEffects.sfxInstance.Audio.PlayOneShot(SoundEffects.sfxInstance.FireAudio);
    }

    void Fire2()
    {
        anim.SetTrigger("shoot2");
        knifePoint.SetActive(true);
        Punch_idle();
    }

    void Punch_idle ()
    {
        StartCoroutine(PunchCoroutine());
    }

    IEnumerator PunchCoroutine()
    {
        yield return new WaitForSeconds(.40f);
        knifePoint.SetActive(false);
    }
}
