using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource source;

    public string name;
    public AudioClip clip;
    [Range(0, 1f)]
    public float volume = .5f;
    public bool loop;
}
