using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIndicatorBehaviour : MonoBehaviour
{
    Transform player;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(DestroyPowerUpIndi());
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up);
        transform.position = player.transform.position;
    }
    IEnumerator DestroyPowerUpIndi()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        playerController.playerHasPowerUp = false;
    }
}
