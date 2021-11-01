using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    public static AudioManager instance;
    public Sound currentSong;
    public int currentSongIndex;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }

        currentSongIndex = 0;
        currentSong = null;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void PlayWithCheck(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void PlayAtPosition(string name, Vector3 pos)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        AudioSource.PlayClipAtPoint(s.clip, pos);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public void PlayStop()
    {
        if (currentSong == null)
        {
            currentSong = sounds[currentSongIndex];
            currentSong.source.Play();
        }
        else
        {
            if (currentSong.source.isPlaying)
            {
                currentSong.source.Pause();
            }
            else
            {
                currentSong.source.Play();
            }
        }
    }

    public void NextTrack()
    {
        if (currentSong == null)
        {
            currentSong = sounds[currentSongIndex];
            currentSong.source.Play();
        }
        else
        {
            if (currentSong.source.isPlaying)
            {
                if (currentSongIndex < sounds.Length - 1)
                {
                    currentSong.source.Stop();
                    currentSongIndex += 1;
                    currentSong = sounds[currentSongIndex];
                    currentSong.source.Play();
                }
                else if (currentSongIndex == sounds.Length - 1)
                {
                    currentSong.source.Stop();
                    currentSongIndex = 0;
                    currentSong = sounds[currentSongIndex];
                    currentSong.source.Play();
                }
            }
            else
            {
                if (currentSongIndex < sounds.Length - 1)
                {
                    currentSongIndex += 1;
                    currentSong = sounds[currentSongIndex];
                }
                else if (currentSongIndex == sounds.Length - 1)
                {
                    currentSongIndex = 0;
                    currentSong = sounds[currentSongIndex];
                }
            }
        }
        
    }
    
    public void PrevTrack()
    {
        if (currentSong == null)
        {
            currentSong = sounds[currentSongIndex];
            currentSong.source.Play();
        }
        else
        {
            if (currentSong.source.isPlaying)
            {
                if (currentSongIndex > 0)
                {
                    currentSong.source.Stop();
                    currentSongIndex -= 1;
                    currentSong = sounds[currentSongIndex];
                    currentSong.source.Play();
                }
                else if (currentSongIndex == 0)
                {
                    currentSong.source.Stop();
                    currentSongIndex = sounds.Length-1;
                    currentSong = sounds[currentSongIndex];
                    currentSong.source.Play();
                }
            }
            else
            {
                if (currentSongIndex > 0)
                {
                    currentSongIndex -= 1;
                    currentSong = sounds[currentSongIndex];
                }
                else if (currentSongIndex == 0)
                {
                    currentSongIndex = sounds.Length-1;
                    currentSong = sounds[currentSongIndex];
                }
            }
        }
        
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    // public void PitchChange(float newPitch)
    // {
    //     currentSong.source.pitch = newPitch;
    // }
}