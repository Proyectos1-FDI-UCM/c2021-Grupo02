using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public Sound[] sounds;

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
        GameManager.GetInstance().SoyElAudioManager(this);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }   
    }

    private void Start()
    {
        Play("MusicaClasica");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }

    }

    public void StopTheMusic()
    {
        Array.Find(sounds, sound => sound.name == "MusicaClasica").source.Stop();
        Array.Find(sounds, sound => sound.name == "MusicaElectronica").source.Stop();
        Array.Find(sounds, sound => sound.name == "MusicaHeavy").source.Stop();
        Array.Find(sounds, sound => sound.name == "MusicaMenu").source.Stop();

    }
}
