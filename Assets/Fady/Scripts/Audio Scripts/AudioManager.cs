using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("---------AudioSource________")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("--------AudioClip___________")]
    public AudioClip EnemyDeath;
    public AudioClip PlayerDeath;
    public AudioClip Collision;
    public AudioClip shoot;
    public AudioClip lose;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void PlayerSFX(AudioClip clip)
    {

        SFXSource.PlayOneShot(clip);
    }
    public void PlayBackGroundMusic(AudioClip clip)
    {
        if (musicSource)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

    }

}
