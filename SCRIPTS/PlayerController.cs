using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed=1;
    Rigidbody rb;
    public GameObject focalGameObject,powerUpIndicator;
    public Transform focal;
    SpawnManager spawnManager;
    public bool playerHasPowerUp = false;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        focal = focalGameObject.GetComponent<Transform>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    
    void Update()
    {
        MovePlayer();
        PlayerIsDead();
    }
    void MovePlayer()
    {
        float verticalForce = Input.GetAxis("Vertical");
        float horizontalForce = Input.GetAxis("Horizontal");
        rb.AddForce(focal.transform.forward* verticalForce * speed, ForceMode.Force);       
        rb.AddForce(focal.transform.right * horizontalForce * speed, ForceMode.Force);
    }
    void PlayerIsDead()
    {
        if (transform.position.y<-10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }
    private void OnCollisionEnter(Collision collision) //TODO
    {
        if (collision.gameObject.name=="Enemy(Clone)"&&playerHasPowerUp==true)
        {
            Debug.Log("COLISION!!!");
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.back * 50, ForceMode.Impulse);
        } 
    }
    private void OnTriggerEnter(Collider other) //TODO
    {
        Destroy(other.gameObject); 
        playerHasPowerUp= true;
        spawnManager.powerUpIsInScene = false;
        Instantiate(powerUpIndicator,transform.position, Quaternion.identity);           
    }
    
}
