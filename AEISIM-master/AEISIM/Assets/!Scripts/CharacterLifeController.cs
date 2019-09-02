using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLifeController : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    [SerializeField]
    private Image characterHealthbar;

    public void DealDamage(float value)
    {
        characterData.PlayerData.objectData.health -= value;
        characterHealthbar.fillAmount -= value/100;
        if(characterData.PlayerData.objectData.health < 0) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("Game over");
    }
}
