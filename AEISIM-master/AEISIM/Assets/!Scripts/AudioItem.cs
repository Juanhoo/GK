using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType {
    MUSIC,
    SOUND
}

[System.Serializable]
public class AudioItem
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioType audioType;

    public AudioSource AudioSource { get => audioSource;}
    public AudioType AudioType { get => audioType;}
}
