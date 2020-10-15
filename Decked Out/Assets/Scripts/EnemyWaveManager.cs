using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    //public event EventHandler OnWaveNumberChanged;

    private enum State {
        WaitingToSpawnNextWave,
        SpawningWave,
    }
    private enum EnemyTypes {
        Circle,
        Square,
        Triangle
    }

    private State state;
    private int waveNumber;
    private float nextWaveSpawnTimer;
    private float nextEnemySpawnTimer;
    private int remainingEnemySpawnAmount;
    [SerializeField] private Vector3 spawnPosition = new Vector3(-229,-362);
    private void Start(){
        state = State.WaitingToSpawnNextWave;
        nextWaveSpawnTimer = 3f;
    }

    private void Update(){
        switch (state) {
                case State.WaitingToSpawnNextWave:
                    nextWaveSpawnTimer -= Time.deltaTime;
                    if (nextWaveSpawnTimer < 0f) {
                        SpawnWave();
                    }
                    break;
                case State.SpawningWave:
                    if (remainingEnemySpawnAmount > 0) {
                        nextEnemySpawnTimer -= Time.deltaTime;
                        if (nextEnemySpawnTimer < 0f) {
                            nextEnemySpawnTimer = 1f;
                            Enemy.Create(spawnPosition, (EnemyTypes)Random.Range(0,3) + "Enemy");
                            remainingEnemySpawnAmount--;
                            

                            if (remainingEnemySpawnAmount <= 0) {
                                PlayerStats.WaveNumber++;
                                state = State.WaitingToSpawnNextWave;
                                nextWaveSpawnTimer = 10f;
                            }
                        }
                    }
                    break;
        }
    }

    private void SpawnWave() {
        remainingEnemySpawnAmount = 5 + 3 * waveNumber;
        state = State.SpawningWave;
        waveNumber++;
        //OnWaveNumberChanged?.Invoke(this, EventArgs.Empty);
    }

}
