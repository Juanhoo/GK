using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/CreateEnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [System.Serializable]
    public class Data {
        [Range(0,100f)]
        public float health;
        [Range(0,5f)]
        public float speed;
        [Range(0,100f)]
        public float damage;

        public Data(float _health, float _speed, float _damage) {
            health = _health;
            speed = _speed;
            damage = _damage;   
        }

        public float GetSpeed() {
            return speed;
        }

        public float GetDamage() {
            return damage;
        }

        public float GetHealth() {
            return health;
        }
    }
    
    [SerializeField]
    public Data objectData;
    public string Name;
}
