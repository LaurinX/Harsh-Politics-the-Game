using System;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] _audio;

    private void Start()
    {
        foreach (AudioSource audioSource in _audio)
        {
            audioSource.Stop();
        }
    }

    public void AudioPlay(int source)
    {
        if (source >= _audio.Length || source < 0)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            _audio[source].Play();
        }
    }

    public void AudioStop(int source)
    {
        if (source >= _audio.Length || source < 0)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            _audio[source].Stop();
        }
    }
}