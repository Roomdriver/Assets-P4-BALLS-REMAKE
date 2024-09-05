using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy, powerUp, powerUpIndicator;
    public int enemyWaveCounter;
    public List<GameObject> enemyList;
    
    void Start()
    {
        enemyWaveCounter = 1;
        enemyList = new List<GameObject>();
        StartCoroutine(SpawnEnemyWave());
        Debug.Log(enemyList.Count);
    }

    void Update()
    {
        if (enemyList.Count == 0 )
        {
            StartCoroutine(SpawnEnemyWave());
        }
        Debug.Log(enemyList.Count);
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
    }

    Vector3 GenerateRandomVector()
    {
        int randNumX = Random.Range(8, -8);
        int randNumY = Random.Range(8, -8);
        Vector3 randomPos=new Vector3(randNumX,0,randNumY);
        return randomPos;
    }
}
