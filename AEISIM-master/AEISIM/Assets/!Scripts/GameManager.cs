using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    private SettingsController settingsController;

    public SettingsController SettingsController { get => settingsController;}
    
    public Action<SceneType> loadSceneByType;

    protected override void Awake() {
        base.Awake();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadScene(int index) {
        loadSceneByType?.Invoke((SceneType)index);
    }
}
