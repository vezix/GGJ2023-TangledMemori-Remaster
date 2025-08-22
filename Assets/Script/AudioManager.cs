using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundBG;
    public Sound[] soundSFX;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Makes this GameObject persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate GameManager instances
        }

        foreach (Sound s in soundBG)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }

        foreach (Sound s in soundSFX)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }
    }

    public void stopAllBG()
    {
        foreach (Sound s in soundBG)
        {
            s.source.Stop();
        }
    }

    public void stopAllSFX()
    {
        foreach (Sound s in soundSFX)
        {
            s.source.Stop();
        }
    }

    public void PlayBG(string name)
    {
        Sound s = Array.Find(soundBG, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else Debug.Log("Sound: " + name + " is Playing!");
        s.source.Play();
    }
    public void StopBG(string name)
    {
        Sound s = Array.Find(soundBG, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else Debug.Log("Sound: " + name + " is Stopped!");
        s.source.Stop();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(soundSFX, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else Debug.Log("Sound: " + name + " is Playing!");
        s.source.Play();
    }

}