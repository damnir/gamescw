using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player player;
    private GameObject checkpoint;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        checkpoint = GameObject.Find("Checkpoint");
        checkpoint.SetActive(false);
    }

    //Enable checkpoint only when the coin is collected, disable the coin
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            this.gameObject.SetActive(false);
            checkpoint.SetActive(true);
        }
    }


}
