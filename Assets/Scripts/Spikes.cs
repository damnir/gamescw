using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject playerGo;
    private Player player;

    void Start()
    {
        player = playerGo.GetComponent<Player>();
    }
    private bool collided = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject == playerGo)
        // {
        //     player.hitSpike();
        //     collided = true;
        // }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        collided = false;
    }
}
