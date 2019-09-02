using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField]
    private Transform currentWindow;

    [SerializeField]
    private Transform notActiveWindow;

    [SerializeField]
    private List<GameObject> optionsWindow;

    public void ChangeScreen(GameObject window) {
        for(int i = 0; i < optionsWindow.Count; ++i) {
            optionsWindow[i].transform.SetParent(notActiveWindow);
        }
        var windowToActivate = optionsWindow.Find(x=>x == window);
        windowToActivate.transform.SetParent(currentWindow);
    }
}
