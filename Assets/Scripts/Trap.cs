using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("Direction")]
    public bool movingY = false;
    public bool movingX = false;
    public int animFrames = 2;
    private Vector2 originalPosition;
    private float startTime;
    public AnimationCurve curve;

    //respawn the player upon collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().respawn();
        }
    }
    //keep start time and position to reset their positions at respawn
    void Start()
    {
        originalPosition = transform.position;
        Debug.Log("starting");
        startTime = Time.time;
    }
    void Update()
    {
        //Evaluate the animation curve based on direction of movement.
        if (movingY)
        {
            transform.position = new Vector2(originalPosition.x,
            curve.Evaluate((Time.time % animFrames)) + originalPosition.y);
        }
        if (movingX)
        {
            transform.position = new Vector2(curve.Evaluate((Time.time - startTime)) + originalPosition.x,
            originalPosition.y);
        }
    }

}
