using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z
    public int enemyCount;
    public int waveCount = 1;
    public YouWinGarabato youWinGarabato;
    // Start is called before the first frame update
    void Start()
    {
        youWinGarabato = FindObjectOfType<YouWinGarabato>();
    }

    // Update is called once per frame
    void Update()
    {
         enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && waveCount<=5 )
        {
            SpawnEnemyWave(3);
        }else if(waveCount>5 && enemyCount == 0){
            youWinGarabato.YouWin();
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        
        

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        waveCount++;
    }
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }
}
