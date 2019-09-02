using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> menuScreens;

    public void OpenScreen(string screenName)
    {
        DisableAllScreens();
        GameObject screenToEnable = menuScreens.Find((x) => x.name == screenName);
        screenToEnable.SetActive(true);
    }

    private void DisableAllScreens()
    {
        menuScreens.ForEach(x =>
        {
            x.SetActive(false);
        });
    }
}
