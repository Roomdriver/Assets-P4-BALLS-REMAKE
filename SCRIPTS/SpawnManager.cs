using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy, powerUp, powerUpIndicator;
    public int enemyWaveCounter;
    public List<GameObject> enemyList;
    public bool powerUpIsInScene=false;
    
    void Start()
    {
        enemyWaveCounter = 1;
        enemyList = new List<GameObject>();
        StartCoroutine(SpawnEnemyWave());        
    }

    void Update()
    {
        if (enemyList.Count == 0 )
        {
            StartCoroutine(SpawnEnemyWave());
        }        
    }
    /// <summary>
    /// spawn 1 enenmy at a random position
    /// Add 1 to counter
    /// </summary>    
    IEnumerator SpawnEnemyWave()
    {        
        for (int i = 0; i < enemyWaveCounter; i++)
        {
            Vector3 randPos = GenerateRandomVector();
            enemyList.Add(Instantiate(enemy,randPos , Quaternion.identity));
            yield return new WaitForSeconds(2);
        }        
        enemyWaveCounter++;
        SpawnPowerUp();
    }
    /// <summary>
    /// if no power up is on scene
    /// spawn 1 powerup at a random position
    /// </summary>
    void SpawnPowerUp()
    {
        if (!powerUpIsInScene)
        {
            Vector3 randPos = GenerateRandomVector();
            Instantiate(powerUp, randPos, Quaternion.identity);
            powerUpIsInScene = true;
        }
    }
    /// <summary>
    /// Generates and returns each time is called a random vector3
    /// </summary>
    /// <returns></returns>
    Vector3 GenerateRandomVector()
    {
        int randNumX = Random.Range(8, -8);
        int randNumY = Random.Range(8, -8);
        Vector3 randomPos=new Vector3(randNumX,0,randNumY);
        return randomPos;
    }
}
