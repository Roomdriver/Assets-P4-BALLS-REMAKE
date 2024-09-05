using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    SpawnManager spawnManager;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    
    void Update()
    {
        EnemyFollowPlayer();
        EnemyDie();
    } 
    void EnemyDie()
    {
        if (transform.position.y < -3)
        {
            spawnManager.enemyList.RemoveAt(0);
            Destroy(gameObject);            
        }
    }
    void EnemyFollowPlayer()
    {
        transform.LookAt(player.transform.position);
        rb.AddForce(transform.forward);  
    }
}
