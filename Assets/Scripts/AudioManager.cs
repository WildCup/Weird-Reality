using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] footSteps;
    public static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return; 
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        foreach (Sound s in footSteps)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, ss => ss.name == name);
        if (s != null)
            s.source.Play();
        else Debug.Log("Sound " + name + " not found");
    }
    void Start()
    {
        Play("Lvl1");
    }
    public void PlayRandom()
    {
        bool isPlaying = false;
        foreach (Sound s in footSteps)
        {
            if (s.source.isPlaying)
                isPlaying = true;
        }
        if (!isPlaying)
        {
            int i = UnityEngine.Random.Range(0, footSteps.Length);
            footSteps[i].source.Play();
        }
    }
}
