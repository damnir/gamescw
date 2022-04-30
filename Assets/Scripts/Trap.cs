using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().respawn();
        }
    }
}
