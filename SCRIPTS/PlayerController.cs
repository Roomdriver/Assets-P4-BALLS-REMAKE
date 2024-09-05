using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=2;
    Rigidbody rb;
    public GameObject focalGameObject;
    public Transform focal;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        focal = focalGameObject.GetComponent<Transform>();  
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
        if (transform.position.y<-3)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) //TODO
    {
            
    }
    private void OnTriggerEnter(Collider other) //TODO
    {
            
    }
}
