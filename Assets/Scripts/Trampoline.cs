using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float trampolineForce = 30000;

    private bool collided = false;
    private float forceAdded = 0f;

    private GameObject player;
    private Rigidbody2D playerRigid;

    private float forceToAdd = 0;
    

    void Start()
    {
        player = GameObject.Find("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        forceToAdd = trampolineForce/6;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            // other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(trampolineForce, 0));
            collided = true;
        }
    }

    void Update()
    {
        if(collided)
        {
            if (forceAdded < trampolineForce)
            {
                playerRigid.AddForce(new Vector2(forceToAdd, 0));
                forceAdded += forceToAdd;
                forceToAdd /= 1.195f;
            }
            else
            {
                collided = false;
                forceAdded = 0;
                forceToAdd = trampolineForce/6;
            }
        }
    }
}