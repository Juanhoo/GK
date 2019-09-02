using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;

    public List<GameObject> Enemies { get => enemies; set => enemies = value; }
}
