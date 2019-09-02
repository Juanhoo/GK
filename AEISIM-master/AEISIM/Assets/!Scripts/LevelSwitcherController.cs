using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcherController : MonoBehaviour
{
    public int nextSceneIndex;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            GameManager.Instance.LoadScene(nextSceneIndex);
        }
    }
}
