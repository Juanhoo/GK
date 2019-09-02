using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyToSpawn;

    [SerializeField]
    private SpawnArea spawnArea;

    [SerializeField]
    private EnemiesController enemiesController;

    [SerializeField]
    private Text waveNumber;

    [SerializeField]
    private Animator waveAnimator;

    private float timer = 0f;
    private float waveTimer = 0f;
    private float betweenWavesTimer = 0f;

    public float timeBetweenWaves;
    public float timeBetweenObjects;

    public float timeWave;

    private void Update() {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;
        if(betweenWavesTimer == 0) {
            if(waveTimer < timeWave) {
                if(timer > timeBetweenObjects) {
                    timer = 0f;
                    SpawnEnemy();
                }
            }
            else {
                betweenWavesTimer += Time.deltaTime;
            }
        }
        else {
            betweenWavesTimer += Time.deltaTime;
            if(betweenWavesTimer > timeBetweenWaves) {
                waveAnimator.SetTrigger("waveStarted");
                waveNumber.text = (int.Parse(waveNumber.text.ToString()) + 1).ToString();
                betweenWavesTimer = 0f;
                waveTimer = 0f;
            }   
        }
        
    }

    private void SpawnEnemy() {
        Vector3 position = spawnArea.GetRandomPositionInArea();
        GameObject enemy = Instantiate(enemyToSpawn, position, Quaternion.identity);
        enemiesController.Enemies.Add(enemy);
    }
}
