using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [System.Serializable]
    public class SettingsContainer {

      [Range(0, 1f)]
      public float MusicVolume = 0.5f;

      [Range(0, 1f)]
      public float SoundsVolume = 0.5f;

      public bool shadowsOn = true;
      public bool vSyncOn = true;

   }

    public SoundSettingsController soundSettingsController;

    [SerializeField]
    private SettingsContainer settingsContainerData = new SettingsContainer();

    public SettingsContainer SettingsContainerData { get => settingsContainerData; }

    private void Awake() {
        SceneManager.sceneLoaded += CheckForNewAudioSources;
    }

    public void CheckForNewAudioSources(Scene scene, LoadSceneMode loadSceneMode) {
        soundSettingsController = FindObjectOfType<SoundSettingsController>();
    }

    public void ChangeMusicVolume(float value) {
        settingsContainerData.MusicVolume = value;
        soundSettingsController.ChangeMusicVolume();
    }

    public void ChangeSoundVolume(float value) {
        settingsContainerData.SoundsVolume = value;
        soundSettingsController.ChangeSoundsVolume();
    }

    public void SetTextureSettings(Dropdown level) {
        switch(level.value) { 
            case 0 :
                QualitySettings.SetQualityLevel(2);
                break;
            case 2:
                QualitySettings.SetQualityLevel(1);
                break;
            case 1:
                QualitySettings.SetQualityLevel(0);
                break;
        }
    }

    public void SetAntialiasingSettings(Dropdown level) {
        switch(level.value) { 
            case 3 :
                QualitySettings.antiAliasing = 4;
                break;
            case 2:
                QualitySettings.antiAliasing = 2;
                break;
            case 1:
                QualitySettings.antiAliasing = 0;
                break;
        }
    }

    public void SetVSync(Toggle toggle) {
        if(!toggle.isOn) {
            QualitySettings.vSyncCount = 0;
            settingsContainerData.vSyncOn = false;
        }
        else {
            QualitySettings.vSyncCount = 2;
            settingsContainerData.vSyncOn = true;
        }
    }

    public void SetShadows(Toggle toggle) {
        if(!toggle.isOn) {
            QualitySettings.shadows = ShadowQuality.Disable;
            settingsContainerData.shadowsOn = false;
        }
        else {
            QualitySettings.shadows = ShadowQuality.All;
            settingsContainerData.shadowsOn = false;
        }
    }
}
