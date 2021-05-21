using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField]
    Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //entregamos la referencia del audio manager al game manager;
       

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }   
    }

    private void Start()
    {
        GameManager.GetInstance().SoyElAudioManager(this);
        Play("MusicaClasica");
        Play("MusicaElectronica");
        Play("MusicaHeavy");
        Play("MusicaMenu");

        ChangeMusic("MusicaClasica");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }

    }

    public void ChangeMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            StopTheMusic();
            s.source.volume = 1;
        }

    }

    void StopTheMusic()
    {
        Array.Find(sounds, sound => sound.name == "MusicaClasica").source.volume = 0;
        Array.Find(sounds, sound => sound.name == "MusicaElectronica").source.volume = 0;
        Array.Find(sounds, sound => sound.name == "MusicaHeavy").source.volume = 0;
        Array.Find(sounds, sound => sound.name == "MusicaMenu").source.volume = 0;
    }

    public void ResetMusic()
    {
        Array.Find(sounds, sound => sound.name == "MusicaClasica").source.Stop();
        Array.Find(sounds, sound => sound.name == "MusicaElectronica").source.Stop();
        Array.Find(sounds, sound => sound.name == "MusicaHeavy").source.Stop();
        Array.Find(sounds, sound => sound.name == "MusicaClasica").source.Play();
        Array.Find(sounds, sound => sound.name == "MusicaElectronica").source.Play();
        Array.Find(sounds, sound => sound.name == "MusicaHeavy").source.Play();
    }
}
