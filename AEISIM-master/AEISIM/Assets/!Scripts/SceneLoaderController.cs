using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType {
    MainMenu,
    Level1,
    Level2, 
    Level3
}

public class SceneLoaderController : MonoBehaviour
{
    private void OnEnable() {
        GameManager.Instance.loadSceneByType += LoadScene;
    }

    private void OnDisable() {
        GameManager.Instance.loadSceneByType -= LoadScene;
    }

    private void LoadScene(SceneType sceneToLoad) {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}
