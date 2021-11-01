using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] public string name;
    [SerializeField] public AudioClip clip;
    [SerializeField] public AudioMixerGroup output;
    [Range(0f,1f)]
    [SerializeField] public float volume;
    [Range(.1f,3)]
    [SerializeField] public float pitch;
    [SerializeField] public bool loop;
    [HideInInspector]
    [SerializeField] public AudioSource source;
}