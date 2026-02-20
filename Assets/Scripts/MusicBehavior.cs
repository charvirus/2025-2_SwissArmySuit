using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehavior : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;
    public static MusicBehavior instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        backmusic = GetComponent<AudioSource>();
    }
    
    public void SetVolume(float volume)
    {
        backmusic.volume = volume;
    }

    public float GetVolume()
    {
        return backmusic.volume;
    }
    
}