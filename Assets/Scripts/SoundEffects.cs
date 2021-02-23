using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip FireAudio;
    public AudioClip JumpAudio;
    public AudioClip KnifeAudio;
    public AudioClip DeadEnemyAudio;
    public AudioClip DeadPlayerAudio;
    public AudioClip WinAudio;
    public AudioClip WhiskeyAudio;
    public AudioClip DeadEnemyAudio2;


    public static SoundEffects sfxInstance;

    private void Awake() 
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
