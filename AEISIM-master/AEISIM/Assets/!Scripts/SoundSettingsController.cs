using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettingsController : MonoBehaviour
{
    
    [SerializeField]
    private List<AudioItem> audioSources;

    public List<AudioItem> AudioSources { get => audioSources; set => audioSources = value; }

    private void OnEnable() {
        for(int i = 0; i < audioSources.Count; ++i) {
            if(audioSources[i].AudioType == AudioType.MUSIC) {
                audioSources[i].AudioSource.volume = GameManager.Instance.SettingsController.SettingsContainerData.MusicVolume;
            }
            else if(audioSources[i].AudioType == AudioType.SOUND) {
                audioSources[i].AudioSource.volume = GameManager.Instance.SettingsController.SettingsContainerData.SoundsVolume;
            }
        }
    }

    public void ChangeMusicVolume()
    {
        for(int i = 0; i < audioSources.Count; ++i) {
            if(audioSources[i].AudioType == AudioType.MUSIC) {
                audioSources[i].AudioSource.volume = GameManager.Instance.SettingsController.SettingsContainerData.MusicVolume;
            }
        }
    }

    public void ChangeSoundsVolume()
    {
        for(int i = 0; i < audioSources.Count; ++i) {
            if(audioSources[i].AudioType == AudioType.SOUND) {
                audioSources[i].AudioSource.volume = GameManager.Instance.SettingsController.SettingsContainerData.SoundsVolume;
            }
        }
    }
}
