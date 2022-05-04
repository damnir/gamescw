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

    public bool directionY = false;


    void Start()
    {
        player = GameObject.Find("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        forceToAdd = trampolineForce / 6; //initial force to add
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            collided = true; //begin collision in update
        }
    }

    float direction;
    //when collided with the trampolie, add force to player's rigidbody in the desired direction
    void Update()
    {
        if (collided)
        {
            if (forceAdded == 0)
            {
                direction = playerRigid.velocity.normalized.x;
            }
            //keep adding force until max force reached
            if (forceAdded < trampolineForce)
            {
                if (directionY)
                {
                    playerRigid.AddForce(new Vector2(0, forceToAdd));
                }
                else
                {
                    playerRigid.AddForce(new Vector2(direction * -forceToAdd, 0));
                }
                forceAdded += forceToAdd;
                forceToAdd /= 1.195f; //keep reducing the force to add to make for a smoother jump
            }
            else
            {
                //reset variables when all force applied, stop the update
                collided = false;
                forceAdded = 0;
                forceToAdd = trampolineForce / 6;
            }
        }
    }
}
