using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttackingController : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            CharacterLifeController characterLifeController = other.GetComponent<CharacterLifeController>();
            characterLifeController.DealDamage(enemyData.objectData.GetDamage());
        }
    }

}
