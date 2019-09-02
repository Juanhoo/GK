using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public PlayerData PlayerData { get => playerData; set => playerData = value; }
}
